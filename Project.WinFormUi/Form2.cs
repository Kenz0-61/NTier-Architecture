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
            ListProducts();
        }

        private void lstProducts_Click(object sender, EventArgs e)
        {
            if (lstProducts.SelectedIndex>1)
            {
                _selected = (ProductVM)lstProducts.SelectedItem;
                txtName.Text = _selected.ProductName;
                txtPrice.Text =_selected.UnitPrice.ToString();
                cmbCategories.SelectedValue = _selected.CategoryID != null ? _selected.CategoryID.Value : -1;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = new Product();
                p.ProductName = txtName.Text;
                p.UnitPrice = Convert.ToDecimal(txtPrice.Text);

                if (cmbCategories.SelectedIndex > -1)
                p.CategoryID = Convert.ToInt32(cmbCategories.SelectedValue);
                
                _dbProductRepo.Add(p);
                ListProducts();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected != null)
            {
                Product toBeDeleted = _dbProductRepo.Find(_selected.ID);
                _dbProductRepo.Delete(toBeDeleted);
                ListProducts();
                _selected = null;
                txtName.Text = txtPrice.Text = null;
                cmbCategories.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Lütfen bir ürün seçinizi ...");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selected != null)
                {
                    Product toBeUpdated = _dbProductRepo.Find(_selected.ID);
                    toBeUpdated.ProductName = txtName.Text;
                    toBeUpdated.UnitPrice = Convert.ToDecimal(txtPrice.Text);
                    if (cmbCategories.SelectedIndex > -1) toBeUpdated.CategoryID = Convert.ToInt32(cmbCategories.SelectedValue);
                    _dbProductRepo.Update(toBeUpdated);
                    ListProducts();
                    _selected = null;
                    txtName.Text = txtPrice.Text = null;
                    cmbCategories.SelectedIndex = -1;
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }    
    }
}
