
namespace ArandaSoftwareData.Model
{
    using ArandaSoftwareData.Helpers;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public  class ArandaModel :DbContext
    {
        public ArandaModel(DbContextOptions options):base(options)
        {

        }
        public ArandaModel()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasIndex(b => b.Username)
                .IsUnique();

            modelBuilder.Entity<Users>()
                .HasIndex(b => b.Email)
                .IsUnique();

            modelBuilder.Entity<Roles>()
              .HasIndex(b => b.RoleName)
              .IsUnique();
            modelBuilder.Entity<Roles>()
                .HasData(new List<Roles> {
                   new Roles{ Id=1, RoleName = "Administrador",DateCreation= DateTime.Now,  },
                   new Roles{ Id=2, RoleName = "Asistente",DateCreation= DateTime.Now},
                   new Roles{ Id=3, RoleName = "Visitante",DateCreation= DateTime.Now},
                   new Roles{ Id=4, RoleName = "Editor",DateCreation= DateTime.Now}
                });

            modelBuilder.Entity<Permisos>()
                .HasData(new List<Permisos> {
                   new Permisos{ Id=1, RolId = 1, Crear=true,Ver=true,Editar=true,Eliminar=true  },
                   new Permisos{ Id=2, RolId = 2, Crear=false,Ver=true,Editar=false,Eliminar=false  },
                   new Permisos{ Id=3, RolId = 3, Crear=false,Ver=false,Editar=false,Eliminar=false  },
                   new Permisos{ Id=4, RolId = 2, Crear=false,Ver=true,Editar=true,Eliminar=false  }
                });
            var pass = Encrypt.GenSHA256("123");
            modelBuilder.Entity<Users>()
             .HasData(new List<Users> {
                   new Users
                   {
                       Id=1, Username = "admon",Email="yeanmagu@gmail.com",Nombres="Administrador del sistema"   ,Block=false,
                       Status=true, Password=pass, RolesId=1
                   }

             }); ;
        }


        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
    }
}
