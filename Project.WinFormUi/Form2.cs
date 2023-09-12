using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.Entites.Models;
using Project.WinFormUi.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.WinFormUi
{
    public partial class Form2 : Form
    {
        ProdcutRepository _dbProductRepo;
        CategoryRepository _dbcategoryRepository;
        public Form2()
        {
            InitializeComponent();
            _dbProductRepo = new ProdcutRepository();
            _dbcategoryRepository = new CategoryRepository();
        }

        void ListCategories()
        {
            cmbCategories.DataSource = _dbcategoryRepository.CustomSelect(x => new CategoryVM
            {
                ID=x.Id,
                CategoryName = x.CategoryName,
                Description = x.Description,
            }).ToList();

            cmbCategories.DisplayMember = "CategoryName";
            cmbCategories.ValueMember = "ID";
        }

        void ListProducts()
        {
            lstProducts.DataSource = _dbProductRepo.CustomSelect(x => new ProductVM
            {
                ID = x.Id,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                CategoryName = x.Category == null ? "Kategorisi Yok" : x.Category.CategoryName,
                CategoryID = x.CategoryID,
            }).ToList();
        }

        ProductVM _selected;

        private void Form2_Load(object sender, EventArgs e)
        {
            ListCategories();
        }
    }
}
