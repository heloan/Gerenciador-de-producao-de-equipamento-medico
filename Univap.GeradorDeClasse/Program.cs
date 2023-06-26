using System;
using System.Data;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            var tableList = new List<string>() { "autenticacao", "responsavel", "fornecedor", "produto", "conformidade", "processo", "venda" };

            foreach(string tableName in tableList) 
            {
                string connString = "server=localhost;database=tecnologia_hospitalar;uid=root;password=root;";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();

                string query = $"SELECT * FROM {tableName} LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable schemaTable = reader.GetSchemaTable();

                // Obter o índice da coluna "DataType" na tabela "SchemaTable"
                int dataTypeColumnIndex = schemaTable.Columns.IndexOf("DataType");

                StringBuilder code = new StringBuilder();

                code.AppendLine($"public class {tableName} {{");

                foreach (DataRow row in schemaTable.Rows)
                {
                    string columnName = row["ColumnName"].ToString();
                    // Obter o tipo de dados da coluna usando o índice da coluna "DataType"
                    string dataType = row[dataTypeColumnIndex].ToString();

                    code.AppendLine($"    public {dataType} {columnName} {{ get; set; }}");
                }

                code.AppendLine("}");

                string fileName = $"{tableName}.cs";
                string filePath = Path.Combine("C:\\Users\\heloa\\OneDrive\\Univap\\Projeto 1\\Sources\\Univap.Projetos1\\Univap.GeradorDeClasse\\Result\\", fileName);

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(code.ToString());
                }
                
                conn.Close();
            }
        }
    }
}