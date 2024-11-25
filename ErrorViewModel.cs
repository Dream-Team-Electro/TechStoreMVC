namespace mvc_web_app.Models
{
        public class Product
        {
            public int Id { get; set; }  // Идентификатор на продукта

            public string Name { get; set; }  // Името на продукта

            public string Category { get; set; }  // Категория на продукта (например "White Goods" или "Black Goods")

            public decimal Price { get; set; }  // Цена на продукта

            public string Description { get; set; }  // Описание на продукта
        }
        public class Category
        {
            public int Id { get; set; }  // Идентификатор на категорията
       
            public string Name { get; set; }  // Името на категорията (например "Бяла техника" или "Черна техника")
        }
}

}
}
