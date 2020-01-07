using System.Collections.Generic;

namespace ARM_Of_Phone_seller_PROJECT.Database_Logic.Таблицы_БД
{
    public class Клиент_Поля
    {
        public int ID_Клиента { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string Номер_паспорта { get; set; }
    }
    public class КлиентModel// : IModel<Клиент_Поля>
    {
        public void Delete(Клиент_Поля item)
        {
            using (DBController db = new DBController())
            {
                db.ExecuteNonQueryCommand($"DELETE FROM Клиент WHERE ID_Клиента = {item.ID_Клиента}");
            }
        }

        public void Insert()
        {
            using (DBController db = new DBController())
            {
                db.ExecuteNonQueryCommand($"INSERT INTO Клиент VALUES (\'\', \'\', \'\', \'\')");
            }
        }

        public IEnumerable<Клиент_Поля> Select()
        {
            using (DBController db = new DBController())
            {
                System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader($"SELECT * FROM Клиент");
                List<Клиент_Поля> list = new List<Клиент_Поля>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Клиент_Поля()
                        {
                            ID_Клиента = reader.GetInt32(0),
                            Фамилия = reader.GetString(1),
                            Имя = reader.GetString(2),
                            Отчество = reader.GetString(3),
                            Номер_паспорта = reader.GetString(4),
                        });
                    }
                }
                return list;
            }
        }

        public void Update(Клиент_Поля item)
        {
            using (DBController db = new DBController())
            {
                db.ExecuteNonQueryCommand($"UPDATE Клиент " +
                    $"SET " +
                    $"Фамилия = \'{item.Фамилия}\'," +
                    $"Имя = \'{item.Имя}\'," +
                    $"Отчество = \'{item.Отчество}\'," +
                    $"Номер_паспорта = \'{item.Номер_паспорта}\' " +
                    $"WHERE ID_Клиента = {item.ID_Клиента}");
            }
        }
    }
}
