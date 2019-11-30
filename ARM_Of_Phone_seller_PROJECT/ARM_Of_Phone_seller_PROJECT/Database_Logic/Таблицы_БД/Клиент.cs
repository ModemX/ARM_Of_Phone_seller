using ARM_Of_Phone_seller_PROJECT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public class КлиентModel : IModel<Клиент_Поля>
    {
        public void Delete(Клиент_Поля item)
        {
            using (var db = new DBController())
            {
                db.ExecuteNonQueryCommand($"DELETE FROM Клиент WHERE ID_Клиента = {item.ID_Клиента}");
            }
        }

        public void Insert(Клиент_Поля item)
        {
            using (var db = new DBController())
            {
                db.ExecuteNonQueryCommand($"INSERT INTO Клиент VALUES (" +
                    $"\'{item.Фамилия}\', " +
                    $"\'{item.Имя}\', " +
                    $"\'{item.Отчество}\', " +
                    $"\'{item.Номер_паспорта}\'" +
                    $")");
            }
        }

        public IEnumerable<Клиент_Поля> Select()
        {
            using (var db = new DBController())
            {
                var reader = db.ExecuteReader($"SELECT * FROM Клиент");
                var list = new List<Клиент_Поля>();

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
            using (var db = new DBController())
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
