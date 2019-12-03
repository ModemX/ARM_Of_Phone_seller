using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ARM_Of_Phone_seller_PROJECT.Database_Logic.Таблицы_БД
{
    class Вызов_представлений_Базы_данных
    {
        
        public IEnumerable Select() //Написать Insert и Delete для представления
        {
            using (var db = new DBController())
            {
                var reader = db.ExecuteReader($"SELECT dbo.Товар.Название_модели AS [Название модели], dbo.Товар.Год_выпуска_модели AS [Год выпуска], dbo.Характеристики.ОЗУ, dbo.Характеристики.Количество_встроенной_памяти AS [Количество встроенной памяти], dbo.Характеристики.Слот_MicroSD AS [Слот MicroSD], dbo.Характеристики.ОС, dbo.Характеристики.Версия_ОС AS [Версия ОС], dbo.Характеристики.Разрешение_камеры AS [Разрешение камеры], dbo.Характеристики.Емкость_аккумулятора AS [Емкость аккумулятора], dbo.Характеристики.Количество_SIM, dbo.Характеристики.Длинна, dbo.Характеристики.Ширина, dbo.Характеристики.Толщина, dbo.Характеристики.Вес FROM dbo.Товар INNER JOIN dbo.Характеристики ON dbo.Товар.ID_Модели = dbo.Характеристики.ID_Модели");
                var list = new List<Модели_И_Их_Характеристики_Поля>();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ArrayList Debug = new ArrayList();

                        Debug.Add(reader.GetString(0));
                        var model = new Модели_И_Их_Характеристики_Поля()
                        {
                            Название_модели = reader.GetString(0),
                            Слот_MicroSD = reader.GetBoolean(4),
                        };

                        if (!reader.IsDBNull(1))
                            model.Год_выпуска_модели = (DateTime?)Convert.ToDateTime(reader.GetValue(1));
                        if (!reader.IsDBNull(2))
                            model.ОЗУ = (double?)Convert.ToDouble(reader.GetValue(2));
                        if (!reader.IsDBNull(3))
                            model.Количество_встроенной_памяти = (double?)Convert.ToDouble(reader.GetValue(3));
                        if (!reader.IsDBNull(5))
                            model.ОС = (string?)reader.GetValue(5);
                        if (!reader.IsDBNull(6))
                            model.Версия_ОС = (string?)reader.GetValue(6);
                        if (!reader.IsDBNull(7))
                            model.Разрешение_камеры = (double?)Convert.ToDouble(reader.GetValue(7));
                        if (!reader.IsDBNull(8))
                            model.Емкость_аккумулятора = (int?)Convert.ToInt32(reader.GetValue(8));
                        if (!reader.IsDBNull(9))
                            model.Количество_SIM = (int?)Convert.ToInt32(reader.GetValue(9));
                        if (!reader.IsDBNull(10))
                            model.Длинна = (double?)Convert.ToDouble(reader.GetValue(10));
                        if (!reader.IsDBNull(11))
                            model.Ширина = (double?)Convert.ToDouble(reader.GetValue(11));
                        if (!reader.IsDBNull(12))
                            model.Толщина = (double?)Convert.ToDouble(reader.GetValue(12));
                        if (!reader.IsDBNull(13))
                            model.Вес = (double?)Convert.ToDouble(reader.GetValue(13));
                        list.Add(model);

                        Debug.Clear();
                    }
                }
                return list;
            }
        }
    }

    class Модели_И_Их_Характеристики_Поля
    {
        public string Название_модели { get; set; }
        public DateTime? Год_выпуска_модели { get; set; }
        public double? ОЗУ { get; set; }
        public double? Количество_встроенной_памяти { get; set; }
        public bool Слот_MicroSD { get; set; }
        public string? ОС { get; set; }
        public string? Версия_ОС { get; set; }
        public double? Разрешение_камеры { get; set; }
        public int? Емкость_аккумулятора { get; set; }
        public int? Количество_SIM { get; set; }
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
        public string Количество_SIM_DataGridBinding
        {
            get
            {
                if (Количество_SIM == null)
                    return "Нет данных";
                else
                    return $"{Количество_SIM}";
            }
            set
            {
                try
                {
                    Количество_SIM = int.Parse(value);
                }
                catch (Exception)
                {
                    Количество_SIM = null;
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
