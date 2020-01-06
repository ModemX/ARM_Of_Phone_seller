using ARM_Of_Phone_seller_PROJECT.Database_Logic;
using System;
using System.Collections.Generic;

namespace ARM_Of_Phone_seller_PROJECT.Model
{
    public class Специалист_Поля
    {
        public int ID_Специалиста { get; set; }
        public string Логин { get; set; }
        public string Пароль { get; set; }
        public long Телефон { get; set; }
        public string Статус { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public DateTime Дата_рождения { get; set; }
        public string Основание_работы { get; set; }
        public bool Администратор { get; set; }

        /*Для DataGrid*/
        public string Дата_рождения_DataGridView
        {
            get => $"" +
                    $"{((Дата_рождения.Day < 10) ? $"0{Дата_рождения.Day}" : $"{Дата_рождения.Day}")}." +
                    $"{((Дата_рождения.Month < 10) ? $"0{Дата_рождения.Month}" : $"{Дата_рождения.Month}")}." +
                    $"{Дата_рождения.Year}";
            set
            {
                try
                {
                    Дата_рождения = Convert.ToDateTime(value);
                }
                catch (Exception)
                {
                    Дата_рождения = new DateTime(2019, 01, 01);
                }
            }
        }
    }
    public class СпециалистModel : IModel<Специалист_Поля>
    {
        public void Delete(Специалист_Поля item)
        {
            using (DBController db = new DBController())
            {
                db.ExecuteNonQueryCommand($"DELETE FROM Специалист WHERE ID_Специалиста = {item.ID_Специалиста}");
            }
        }
        public void Insert(Специалист_Поля item)
        {
            using (DBController db = new DBController())
            {
                db.ExecuteNonQueryCommand($"INSERT INTO Специалист VALUES (N\'{item.Логин}\', N\'{item.Пароль}\', {item.Телефон}, N\'{item.Статус}\', N\'{item.Фамилия}\', N\'{item.Имя}\', N\'{item.Отчество}\', \'{GetDate(item.Дата_рождения)}\', N\'{item.Основание_работы}\', \'{item.Администратор.ToString().ToLower()}\')");
            }
        }
        public IEnumerable<Специалист_Поля> Select()
        {
            using (DBController db = new DBController())
            {
                List<Специалист_Поля> list = new List<Специалист_Поля>();

                if (!db.ErrorOccured)
                {
                    System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader($"SELECT * FROM Специалист");

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(new Специалист_Поля()
                            {
                                ID_Специалиста = reader.GetInt32(0),
                                Логин = reader.GetString(1),
                                Пароль = reader.GetString(2),
                                Телефон = reader.GetInt64(3),
                                Статус = reader.GetString(4),
                                Фамилия = reader.GetString(5),
                                Имя = reader.GetString(6),
                                Отчество = reader.GetString(7),
                                Дата_рождения = reader.GetDateTime(8),
                                Основание_работы = reader.GetString(9),
                                Администратор = reader.GetBoolean(10)
                            });
                        }
                    }
                }
                return list;
            }
        }
        public void Update(Специалист_Поля item)
        {
            using (DBController db = new DBController())
            {
                db.ExecuteNonQueryCommand($"UPDATE Специалист SET Логин = N\'{item.Логин}\', Пароль = N\'{item.Пароль}\', Телефон = {item.Телефон}, Статус = N\'{item.Статус}\', Фамилия = N\'{item.Фамилия}\', Имя = N\'{item.Имя}\', Отчество = N\'{item.Отчество}\', Дата_рождения = \'{GetDate(item.Дата_рождения)}\', Основание_работы = N\'{item.Основание_работы}\', Администратор = \'{item.Администратор.ToString().ToLower()}\' where ID_Специалиста = {item.ID_Специалиста}");
            }
        }

        private string GetDate(DateTime date)
        {
            return $"{date.Day}/{date.Month}/{date.Year}";
        }
    }
}
