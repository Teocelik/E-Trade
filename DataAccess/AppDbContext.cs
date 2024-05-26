using E_Trade.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Trade.DataAccess
{
    public class AppDbContext:DbContext
    {
        #region Info
        //Bu kod örneğinde AppDbContext adında bir sınıf tanımlanmıştır. Bu sınıfın amacı, Entity Framework Core kullanarak veritabanı işlemlerini yönetmek için bir DbContext sınıfı oluşturmaktır. Aşağıda bu sınıfın temel amacıyla ilgili açıklamalar verilmiştir:

        //AppDbContext sınıfı, Entity Framework Core tarafından sağlanan DbContext sınıfını miras alır. DbContext, veritabanı işlemleri yapmak için gerekli olan API'leri sağlar.
        //Constructor içinde bulunan DbContextOptions parametresi, AppDbContext sınıfının yapılandırma seçeneklerini alır. Bu seçenekler, DbContext'in veritabanı bağlantısı ve davranışıyla ilgili bilgileri içerir.
        //base(options) ifadesi, DbContext sınıfının base constructor'ını çağırarak, AppDbContext sınıfının yapılandırılmasını sağlar. Bu yapılandırma işlemi, veritabanına bağlanmak ve DbContext'i ayarlamak için gereklidir.
        //base(options): DbContext sınıfının yapıcı metodunu çağırarak AppDbContext sınıfını oluşturur. base anahtar kelimesi, DbContext sınıfını işaret eder. Bu çağrı, DbContext sınıfının yapıcı metoduna options parametresini ileterek DbContext'i yapılandırır.
        #endregion

        //  DbSet'ler(public DbSet<Product> Products { get; set; }), veritabanındaki belirli bir tabloya karşılık gelir.(burada products tablosuna karşılık gelmiştir.)
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
