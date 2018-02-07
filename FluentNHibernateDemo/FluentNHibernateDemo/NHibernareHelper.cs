using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace FluentNHibernateDemo
{

    public class NHibernateHelper
    {

        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory(); return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()         
			// Connection String eh a Configuracoes do Banco de Dados
            // Data Source eh o local. "." Siginifica LOCALHOST
            // Initial Catalog eh o Nome do Banco de Dados
            // Integrated Security eh o metodo de seguranca
             .Database(MsSqlConfiguration.MsSql2012
             .ConnectionString("Data Source=.;Initial Catalog=NHibernateDemo;Integrated Security=SSPI;")
             .ShowSql())

         .Mappings(m => m.FluentMappings
         
         .AddFromAssemblyOf<Program>())
         .ExposeConfiguration(cfg => new SchemaExport(cfg)
         .Create(true, true))
         
         .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}