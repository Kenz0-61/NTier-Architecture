﻿using Project.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Map.Options
{
    public class CategoryMap:BaseMap<Category>
    {
        public CategoryMap()
        {
            ToTable("Kategoriler");
            Property(x=> x.CategoryName).HasColumnName("KategoriAdı");
            Property(x=> x.Description).HasColumnName("Açıklama");

        }
    }
}
