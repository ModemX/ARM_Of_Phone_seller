using ARM_Of_Phone_seller_PROJECT.Model;
using System;
using System.Collections.Generic;

namespace ARM_Of_Phone_seller_PROJECT.Database_Logic.Таблицы_БД
{
    class Вызов_представлений_Базы_данных : IModel<Модели_И_Их_Характеристики_Поля>
    {
        public void Delete(Модели_И_Их_Характеристики_Поля item)
        {
            using (DBController db = new DBController())
            {
                db.ExecuteNonQueryCommand($"delete from Характеристики where ID_Модели = \'{item.ID_Модели}\'");
            }
        }

        public void Insert(Модели_И_Их_Характеристики_Поля item)
        {
            throw new NotImplementedException();
        }

        public void InsertEmptyEntry()
        {
            using (DBController db = new DBController())
            {
                string debug = "exec InsertEmptyEntry";
                db.ExecuteNonQueryCommand(debug);
            }
        }

        public IEnumerable<Модели_И_Их_Характеристики_Поля> Select()
        {
            using (DBController db = new DBController())
            {
                System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader($"SELECT dbo.Товар.ID_Модели, dbo.Товар.Название_модели AS [Название модели], dbo.Товар.Год_выпуска_модели AS [Год выпуска], dbo.Характеристики.ОЗУ, dbo.Характеристики.Количество_встроенной_памяти AS [Количество встроенной памяти], dbo.Характеристики.Слот_MicroSD AS [Слот MicroSD], dbo.Характеристики.ОС, dbo.Характеристики.Версия_ОС AS [Версия ОС], dbo.Характеристики.Разрешение_камеры AS [Разрешение камеры], dbo.Характеристики.Емкость_аккумулятора AS [Емкость аккумулятора], dbo.Характеристики.Количество_SIM, dbo.Характеристики.Длинна, dbo.Характеристики.Ширина, dbo.Характеристики.Толщина, dbo.Характеристики.Вес FROM dbo.Товар INNER JOIN dbo.Характеристики ON dbo.Товар.ID_Модели = dbo.Характеристики.ID_Модели");
                List<Модели_И_Их_Характеристики_Поля> list = new List<Модели_И_Их_Характеристики_Поля>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Модели_И_Их_Характеристики_Поля model = new Модели_И_Их_Характеристики_Поля()
                        {
                            ID_Модели = reader.GetInt32(0),
                            Название_модели = reader.GetString(1),
                            Слот_MicroSD = reader.GetBoolean(5),
                            Количество_SIM = reader.GetInt32(10),
                        };

                        if (!reader.IsDBNull(2))
                            model.Год_выпуска_модели = (DateTime?)Convert.ToDateTime(reader.GetValue(2));
                        if (!reader.IsDBNull(3))
                            model.ОЗУ = Convert.ToDouble(reader.GetValue(3));
                        if (!reader.IsDBNull(4))
                            model.Количество_встроенной_памяти = Convert.ToDouble(reader.GetValue(4));
                        if (!reader.IsDBNull(6))
                            model.ОС = (string?)reader.GetValue(6);
                        if (!reader.IsDBNull(7))
                            model.Версия_ОС = (string?)reader.GetValue(7);
                        if (!reader.IsDBNull(8))
                            model.Разрешение_камеры = Convert.ToDouble(reader.GetValue(8));
                        if (!reader.IsDBNull(9))
                            model.Емкость_аккумулятора = Convert.ToInt32(reader.GetValue(9));
                        if (!reader.IsDBNull(11))
                            model.Длинна = Convert.ToDouble(reader.GetValue(11));
                        if (!reader.IsDBNull(12))
                            model.Ширина = Convert.ToDouble(reader.GetValue(12));
                        if (!reader.IsDBNull(13))
                            model.Толщина = Convert.ToDouble(reader.GetValue(13));
                        if (!reader.IsDBNull(14))
                            model.Вес = Convert.ToDouble(reader.GetValue(14));
                        list.Add(model);
                    }
                }
                return list;
            }
        }

        public void Update(Модели_И_Их_Характеристики_Поля item)
        {
            using (DBController db = new DBController())
            {
                db.ExecuteNonQueryCommand($"exec UpdateLine_Модели_И_Их_Характеристики " +
                    $"{item.ID_Модели}, " +
                    $"{((item.Название_модели == null) ? "NULL" : $"N\'{item.Название_модели}\'")}, " +
                    $"{((item.Год_выпуска_модели == null) ? "NULL" : $"\'{item.Год_выпуска_модели.ToString()}\'")}, " +
                    $"{((item.ОЗУ == null) ? "NULL" : $"{ReplaceComaToDot(item.ОЗУ)}")}, " +
                    $"{((item.Количество_встроенной_памяти == null) ? "NULL" : $"{ReplaceComaToDot(item.Количество_встроенной_памяти)}")}, " +
                    $"\'{item.Слот_MicroSD}\', " +
                    $"{((item.ОС == null) ? "NULL" : $"N\'{item.ОС}\'")}, " +
                    $"{((item.Версия_ОС == null) ? "NULL" : $"N\'{item.Версия_ОС}\'")}, " +
                    $"{((item.Разрешение_камеры == null) ? "NULL" : $"{ReplaceComaToDot(item.Разрешение_камеры)}")}, " +
                    $"{((item.Емкость_аккумулятора == null) ? "NULL" : $"{item.Емкость_аккумулятора.ToString()}")}, " +
                    $"\'{item.Количество_SIM}\', " +
                    $"{((item.Длинна == null) ? "NULL" : $"{ReplaceComaToDot(item.Длинна)}")}, " +
                    $"{((item.Ширина == null) ? "NULL" : $"{ReplaceComaToDot(item.Ширина)}")}, " +
                    $"{((item.Толщина == null) ? "NULL" : $"{ReplaceComaToDot(item.Толщина)}")}, " +
                    $"{((item.Вес == null) ? "NULL" : $"{ReplaceComaToDot(item.Вес)}")}");
            }
        }

        public IEnumerable<Модели_И_Их_Характеристики_Поля> SearchByCharacteristics(string MyValue)
        {
            using (DBController db = new DBController())
            {
                System.Data.SqlClient.SqlDataReader reader = db.ExecuteReader($"exec SearchByCharacteristics \'{MyValue}\'");
                List<Модели_И_Их_Характеристики_Поля> list = new List<Модели_И_Их_Характеристики_Поля>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Модели_И_Их_Характеристики_Поля model = new Модели_И_Их_Характеристики_Поля()
                        {
                            ID_Модели = reader.GetInt32(0),
                            Название_модели = reader.GetString(1),
                            Слот_MicroSD = reader.GetBoolean(5),
                            Количество_SIM = reader.GetInt32(10),
                        };

                        if (!reader.IsDBNull(2))
                            model.Год_выпуска_модели = (DateTime?)Convert.ToDateTime(reader.GetValue(2));
                        if (!reader.IsDBNull(3))
                            model.ОЗУ = Convert.ToDouble(reader.GetValue(3));
                        if (!reader.IsDBNull(4))
                            model.Количество_встроенной_памяти = Convert.ToDouble(reader.GetValue(4));
                        if (!reader.IsDBNull(6))
                            model.ОС = (string?)reader.GetValue(6);
                        if (!reader.IsDBNull(7))
                            model.Версия_ОС = (string?)reader.GetValue(7);
                        if (!reader.IsDBNull(8))
                            model.Разрешение_камеры = Convert.ToDouble(reader.GetValue(8));
                        if (!reader.IsDBNull(9))
                            model.Емкость_аккумулятора = Convert.ToInt32(reader.GetValue(9));
                        if (!reader.IsDBNull(11))
                            model.Длинна = Convert.ToDouble(reader.GetValue(11));
                        if (!reader.IsDBNull(12))
                            model.Ширина = Convert.ToDouble(reader.GetValue(12));
                        if (!reader.IsDBNull(13))
                            model.Толщина = Convert.ToDouble(reader.GetValue(13));
                        if (!reader.IsDBNull(14))
                            model.Вес = Convert.ToDouble(reader.GetValue(14));
                        list.Add(model);
                    }
                }
                return list;
            }
        }

        private string GetDate(DateTime date)
        {
            return $"{date.Day}/{date.Month}/{date.Year}";
        }
        private string GetDate(DateTime? date)
        {
            if (date == null)
                return null;
            else
                return GetDate(Convert.ToDateTime(date));
        }
        private string ReplaceComaToDot(double? number)
        {
            return number.ToString().Replace(',', '.');
        }
    }

    class Модели_И_Их_Характеристики_Поля
    {
        public int ID_Модели { get; set; }
        public string Название_модели { get; set; }
        public DateTime? Год_выпуска_модели { get; set; }
        public double? ОЗУ { get; set; }
        public double? Количество_встроенной_памяти { get; set; }
        public bool Слот_MicroSD { get; set; }
        public string? ОС { get; set; }
        public string? Версия_ОС { get; set; }
        public double? Разрешение_камеры { get; set; }
        public int? Емкость_аккумулятора { get; set; }
        public int Количество_SIM { get; set; }
        public double? Длинна { get; set; }
        public double? Ширина { get; set; }
        public double? Толщина { get; set; }
        public double? Вес { get; set; }

        /*  Binding'и для DataGrid, принимающие значения NULL  */
        public string Год_Выпуска_Модели_DataGridBinding
        {
            get
            {
                if (Год_выпуска_модели == null)
                    return "Нет данных";
                return Год_выпуска_модели.Value.Year.ToString();
            }
            set
            {
                try
                {
                    int.Parse(value);
                    Год_выпуска_модели = new DateTime(int.Parse(value), 1, 1);
                }
                catch (Exception)
                {
                    Год_выпуска_модели = null;
                }
            }
        }
        public string ОЗУ_DataGridBinding
        {
            get
            {
                if (ОЗУ == null)
                    return "Нет данных";
                else
                    if (ОЗУ < 1)
                    return $"{ОЗУ * 1000} МБ";
                else
                    return $"{ОЗУ} ГБ";
            }
            set
            {
                try
                {
                    ОЗУ = double.Parse(value);
                }
                catch (Exception)
                {
                    try
                    {
                        char[] splitOptions = { ' ' };
                        string[] РазделеннаяСтрока;
                        РазделеннаяСтрока = value.Split(splitOptions);
                        if (РазделеннаяСтрока[1] == "МБ")
                            ОЗУ = (Convert.ToDouble(РазделеннаяСтрока[0]) / 1000);
                        else if (РазделеннаяСтрока[1] == "ГБ")
                            ОЗУ = (Convert.ToDouble(РазделеннаяСтрока[0]));
                        else throw new Exception();
                    }
                    catch (Exception)
                    {
                        ОЗУ = null;
                    }
                }
            }
        }
        public string Количество_встроенной_памяти_DataGridBinding
        {
            get
            {
                if (Количество_встроенной_памяти == null)
                    return "Нет данных";
                else
                    if (Количество_встроенной_памяти < 1)
                    return $"{Количество_встроенной_памяти * 1000} МБ";
                else
                    return $"{Количество_встроенной_памяти} ГБ";
            }
            set
            {
                try
                {
                    char[] splitOptions = { ' ' };
                    string[] РазделеннаяСтрока;
                    РазделеннаяСтрока = value.Split(splitOptions);
                    if (РазделеннаяСтрока[1] == "МБ")
                        Количество_встроенной_памяти = (Convert.ToDouble(РазделеннаяСтрока[0]) / 1000);
                    else if (РазделеннаяСтрока[1] == "ГБ")
                        Количество_встроенной_памяти = (Convert.ToDouble(РазделеннаяСтрока[0]));
                    else throw new Exception();
                }
                catch (Exception)
                {
                    Количество_встроенной_памяти = null;
                }
            }
        }
        public string Слот_MicroSD_DataGridBinding
        {
            get
            {
                if (Слот_MicroSD)
                    return "Присутствует";
                else
                    return "Отсутствует";
            }
            set
            {
                if (value == "Присутствует")
                    Слот_MicroSD = true;
                else
                    Слот_MicroSD = false;
            }
        }
        public string ОС_DataGridBinding
        {
            get
            {
                if (ОС == null)
                    return "Нет данных";
                return ОС;
            }
            set
            {
                if (value == "Нет данных")
                    ОС = null;
                else
                    ОС = value;
            }
        }
        public string Версия_ОС_DataGridBinding
        {
            get
            {
                if (Версия_ОС == null)
                    return "Нет данных";
                return Версия_ОС;
            }
            set
            {
                if (value == "Нет данных")
                    Версия_ОС = null;
                else
                    Версия_ОС = value;
            }
        }
        public string Разрешение_камеры_DataGridBinding
        {
            get
            {
                if (Разрешение_камеры == null)
                    return "Нет данных";
                else
                    return $"{Разрешение_камеры} Мп";
            }
            set
            {
                try
                {
                    char[] splitOptions = { ' ' };
                    string[] РазделеннаяСтрока;
                    РазделеннаяСтрока = value.Split(splitOptions);
                    if (РазделеннаяСтрока[1] == "Мп")
                        Разрешение_камеры = (Convert.ToDouble(РазделеннаяСтрока[0]));
                    else throw new Exception();
                }
                catch (Exception)
                {
                    Разрешение_камеры = null;
                }
            }
        }
        public string Емкость_аккумулятора_DataGridBinding
        {
            get
            {
                if (Емкость_аккумулятора == null)
                    return "Нет данных";
                else
                    return $"{Емкость_аккумулятора} мАч";
            }
            set
            {
                try
                {
                    char[] splitOptions = { ' ' };
                    string[] РазделеннаяСтрока;
                    РазделеннаяСтрока = value.Split(splitOptions);
                    Количество_встроенной_памяти = (Convert.ToInt32(РазделеннаяСтрока[0]));
                }
                catch (Exception)
                {
                    Количество_встроенной_памяти = null;
                }
            }

        }
        public string Длинна_DataGridBinding
        {
            get
            {
                if (Длинна == null)
                    return "Нет данных";
                else
                    return $"{Длинна} мм";
            }
            set
            {
                try
                {
                    char[] splitOptions = { ' ' };
                    string[] РазделеннаяСтрока;
                    РазделеннаяСтрока = value.Split(splitOptions);
                    Длинна = (Convert.ToDouble(РазделеннаяСтрока[0]));
                }
                catch (Exception)
                {
                    Длинна = null;
                }
            }
        }
        public string Ширина_DataGridBinding
        {
            get
            {
                if (Ширина == null)
                    return "Нет данных";
                else
                    return $"{Ширина} мм";
            }
            set
            {
                try
                {
                    char[] splitOptions = { ' ' };
                    string[] РазделеннаяСтрока;
                    РазделеннаяСтрока = value.Split(splitOptions);
                    Ширина = (Convert.ToDouble(РазделеннаяСтрока[0]));
                }
                catch (Exception)
                {
                    Ширина = null;
                }
            }
        }
        public string Толщина_DataGridBinding
        {
            get
            {
                if (Толщина == null)
                    return "Нет данных";
                else
                    return $"{Толщина} мм";
            }
            set
            {
                try
                {
                    char[] splitOptions = { ' ' };
                    string[] РазделеннаяСтрока;
                    РазделеннаяСтрока = value.Split(splitOptions);
                    Толщина = (Convert.ToDouble(РазделеннаяСтрока[0]));
                }
                catch (Exception)
                {
                    Толщина = null;
                }
            }
        }
        public string Вес_DataGridBinding
        {
            get
            {
                if (Вес == null)
                    return "Нет данных";
                else
                    return $"{Вес} г";
            }
            set
            {
                try
                {
                    char[] splitOptions = { ' ' };
                    string[] РазделеннаяСтрока;
                    РазделеннаяСтрока = value.Split(splitOptions);
                    Вес = (Convert.ToDouble(РазделеннаяСтрока[0]));
                }
                catch (Exception)
                {
                    Вес = null;
                }
            }
        }

    }
}
