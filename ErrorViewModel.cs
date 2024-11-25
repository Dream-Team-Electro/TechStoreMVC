namespace mvc_web_app.Models
{
        public class Product
        {
            public int Id { get; set; }  // ������������� �� ��������

            public string Name { get; set; }  // ����� �� ��������

            public string Category { get; set; }  // ��������� �� �������� (�������� "White Goods" ��� "Black Goods")

            public decimal Price { get; set; }  // ���� �� ��������

            public string Description { get; set; }  // �������� �� ��������
        }
        public class Category
        {
            public int Id { get; set; }  // ������������� �� �����������
       
            public string Name { get; set; }  // ����� �� ����������� (�������� "���� �������" ��� "����� �������")
        }
}

}
}
