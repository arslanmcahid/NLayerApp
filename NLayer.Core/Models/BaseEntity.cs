namespace NLayer.Core.Models
{
    public abstract class BaseEntity // soyut sınıf oldu new anahtar sözcüğü ile oluşturulamayacak
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        //UpdatedDate ilk girişte null olması gerekiyor
    }
}
