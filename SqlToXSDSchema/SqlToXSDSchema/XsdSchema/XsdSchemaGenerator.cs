using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SqlToXSDSchema.XsdSchema;
public class XsdSchemaGenerator
{
    public async Task<string> ConvertToXsdAsync(string connectionString, DataTable dataTable)
    {
        try
        {
            if(string.IsNullOrEmpty(dataTable.TableName))
            {
                dataTable.TableName = "SqlTable";
            }

            XmlDocument xmlDocument = new XmlDocument();
            using (MemoryStream stream = new MemoryStream())
            {
                dataTable.WriteXml(stream);
                stream.Position = 0;
                xmlDocument.Load(stream);
            }

            XmlReader xmlReader = new XmlNodeReader(xmlDocument);
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            XmlSchemaInference schemaInference = new XmlSchemaInference();
            schemaSet = schemaInference.InferSchema(xmlReader);

            StringWriter stringWriter = new StringWriter();
            foreach (XmlSchema schema in schemaSet.Schemas())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XmlSchema));
                serializer.Serialize(stringWriter, schema);
            }

            return stringWriter.ToString();
        }
        catch (SqlException ex)
        {
            return null;
        }
        catch (XmlSchemaInferenceException ex)
        {
            return null;
        }
    }
}
