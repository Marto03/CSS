using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SqlToXSDSchema.XsdSchema;
public class XsdSchemaGenerator
{
    public async Task<string?> ConvertToXsdAsync(string connectionString, DataTable dataTable)
    {
        try
        {
            dataTable.TableName = "NewDataSet";

            StringBuilder schemaBuilder = new StringBuilder();
            schemaBuilder.AppendLine("<?xml version=\"1.0\" standalone=\"yes\"?>");
            schemaBuilder.AppendLine("<xs:schema id=\"NewDataSet\" xmlns=\"\" xmlns:xs=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\">");
            schemaBuilder.AppendLine("  <xs:element name=\"" + dataTable.TableName + "\" msdata:IsDataSet=\"true\" msdata:UseCurrentLocale=\"true\">");
            schemaBuilder.AppendLine("    <xs:complexType>");
            schemaBuilder.AppendLine("      <xs:choice minOccurs=\"0\" maxOccurs=\"unbounded\">");
            schemaBuilder.AppendLine("        <xs:element name=\"SourceTable\">");
            schemaBuilder.AppendLine("          <xs:complexType>");
            schemaBuilder.AppendLine("            <xs:sequence>");

            foreach (DataColumn column in dataTable.Columns)
            {
                string columnType = GetXmlSchemaType(column.DataType);
                schemaBuilder.AppendLine("              <xs:element name=\"" + column.ColumnName + "\" type=\"" + columnType + "\" minOccurs=\"0\" />");
            }

            schemaBuilder.AppendLine("            </xs:sequence>");
            schemaBuilder.AppendLine("          </xs:complexType>");
            schemaBuilder.AppendLine("        </xs:element>");
            schemaBuilder.AppendLine("      </xs:choice>");
            schemaBuilder.AppendLine("    </xs:complexType>");
            schemaBuilder.AppendLine("  </xs:element>");
            schemaBuilder.AppendLine("</xs:schema>");

            return schemaBuilder.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error converting to XSD: " + ex.Message);
            return null;
        }
    }

    private string GetXmlSchemaType(Type dataType)
    {
        if (dataType == typeof(string)) return "xs:string";
        else if (dataType == typeof(bool)) return "xs:boolean";
        else if ((dataType == typeof(byte)) || dataType == typeof(sbyte)) return "xs:byte";
        else if (dataType == typeof(short)) return "xs:short";
        else if (dataType == typeof(ushort)) return "xs:unsignedShort";
        else if (dataType == typeof(int)) return "xs:int";
        else if (dataType == typeof(uint)) return "xs:unsignedInt";
        else if (dataType == typeof(long)) return "xs:long";
        else if (dataType == typeof(ulong)) return "xs:unsignedLong";
        else if (dataType == typeof(float)) return "xs:float";
        else if (dataType == typeof(double)) return "xs:double";
        else if (dataType == typeof(decimal)) return "xs:decimal";
        else if (dataType == typeof(DateTime)) return "xs:dateTime";
        else if (dataType == typeof(TimeSpan)) return "xs:duration";
        else if (dataType == typeof(Guid)) return "xs:guid";
        else return "xs:string";
    }
}
