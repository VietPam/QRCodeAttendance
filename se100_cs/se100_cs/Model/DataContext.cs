﻿using Microsoft.EntityFrameworkCore;

namespace se100_cs.Model
{
    public class DataContext : DbContext
    {
        public static Random random = new();
        public DbSet<SqlEmployee>? employees { get; set; }
        public DbSet<SqlDepartment> departments { get; set; }
        public DbSet<SqlAttendance>? attendances { get; set; }
        public DbSet<SqlState> ATD_state { get; set; }
        public DbSet<SqlPosition>? positions { get; set; }
        public DbSet<SqlRole>? roles { get; set; }
        public DbSet<SqlSetting> settings { get; set; }

        public static string randomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(chars.Length)]).ToArray());
        }
        public static string configSql = "Host=localhost:5434;Database=db_se100;Username=postgres;Password=12345678";
        public static int Generate_UID()
        {
            int minValue = 200000000;
            int maxValue = 999999999;

            return random.Next(minValue, maxValue + 1); // +1 to include the maxValue
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(configSql);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
