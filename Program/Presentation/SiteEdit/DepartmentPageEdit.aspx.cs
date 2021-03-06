﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.SiteEdit
{
	public partial class DepartmentPageEdit: System.Web.UI.Page
	{
        private BusinessCode _business = new BusinessCode();
        string sortingPar = "";

        private List<List<string>> GetData()
        {
            return (List<List<string>>)Session["ListDataSession"];
        }

        private List<int> GetDataIDs()
        {
            return (List<int>)Session["DataID"];
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            UserCode user = (UserCode) Session["authenticatedUser"];
            if (user == null)
            {
                Response.Redirect("../index.aspx");
            }
            SetDropdownContent();
            if (!IsPostBack)
            {
                List<List<string>> ListData = GetData();
                if (ListData != null)
                {
                    InsertData();
                }

                Session["ListDataSession"] = null;
            }
        }

        private UserCode GetCurrentUser(int ID)
        {
            UserCode user = new UserCode();
            user = _business.GetUsers("WHERE User_ID = " + ID)[0];
            return user;
        }

        private void InsertData()
        {
            List<List<string>> ListData = GetData();
            int Count = 0;
            for (int i = 0; i < ListData.Count; i++)
            {
                for (int i2 = 0; i2 <= 3; i2++)
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var container = Master.FindControl("Body");
                    var txtBox = container.FindControl(tbName);

                    switch (i2)
                    {
                        case 0:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;

                        case 1:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;

                        case 2:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;
                    }

                    string ddName = "ddEdit" + i.ToString() + 0.ToString();
                    var dd = container.FindControl(ddName) as DropDownList;

                    //hospitalID krijgen van de current row in de gridvieuw
                    sortingPar = string.Format(" WHERE Department_ID = {0}", GetDataIDs()[i]);
                    List<DepartmentCode> CurrentDepartment = new List<DepartmentCode>();
                    CurrentDepartment = _business.GetDepartments(sortingPar);
                    int hospitalID = CurrentDepartment[0].HospitalID;

                    //de hospital selecteren in de dropdown
                    ListItem li = dd.Items.FindByValue(hospitalID.ToString());
                    dd.ClearSelection();
                    li.Selected = true;
                    Count++;
                }
            }
        }

        private void SendData()
        {

            var container = Master.FindControl("Body");
            List<List<string>> ListContentHospital = _business.GetHospitalDropDownContent();
            for (int i = 0; i <= 9; i++)
            {
                string[] input = new string[10];

                for (int i2 = 0; i2 <= 9; i2++)
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var txtBox = container.FindControl(tbName);

                    switch (i2)
                    {
                        case 0:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                goto track1;
                            }
                            else
                            {

                                input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            }
                            break;

                        case 1:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                if (_business.IsValidEmail(((TextBox)txtBox).Text.ToString()))
                                {
                                    input[i2] = (((TextBox)txtBox).Text.ToString());
                                }
                                else
                                {
                                    //error---------------------------------------
                                    input[i2] = "error invalid email";
                                }
                            }

                            break;

                        case 2:
                            if (String.IsNullOrWhiteSpace(((TextBox)txtBox).Text.ToString()))
                            {
                                input[i2] = "";
                            }
                            else
                            {
                                if (_business.IsValidPhone(((TextBox)txtBox).Text.ToString()))
                                {
                                    input[i2] = (((TextBox)txtBox).Text.ToString());
                                }
                                else
                                {
                                    //error---------------------------------------
                                    input[i2] = "error invalid phone";
                                }
                            }
                            break;
                    }
                }
                string ddName = "ddEdit" + i.ToString() + "0";
                var dropdownData = container.FindControl(ddName) as DropDownList;
                int index = dropdownData.SelectedIndex;

                UserCode LoginUser = (UserCode)Session["authenticatedUser"];
                UserCode user = GetCurrentUser(LoginUser.ID);

                DateTime dt = DateTime.Now;
                string dateNow = dt.ToString("yyyy-MM-dd");

                _business.AddDepartment(new DepartmentCode(0,input[0], input[1], input[2], Convert.ToInt16(ListContentHospital[index - 1][0]), user.ID, Convert.ToDateTime(dateNow), Convert.ToDateTime(dateNow)));
                track1:
                continue;
            }
        }

        private void UpdateData()
        {
            List<int> ListDataIDs = GetDataIDs();
            for (int i = 0; i <= 9; i++)
            {
                string[] input = new string[3];
                var container = Master.FindControl("Body");

                for (int i2 = 0; i2 <= 2; i2++)
                {
                    string tbName = "tbEdit" + i.ToString() + i2.ToString();
                    var txtBox = container.FindControl(tbName);

                    switch (i2)
                    {
                        case 0:
                            if (((TextBox)txtBox).Text != "")
                            {
                                input[i2] = _business.BeginUpperCase((((TextBox)txtBox).Text.ToString()));
                            }
                            else
                            {
                                goto track1;
                            }
                            break;

                        case 1:
                            if (((TextBox)txtBox).Text == "")
                            {
                                if (_business.IsValidEmail(((TextBox)txtBox).Text.ToString()))
                                {
                                    input[i2] = (((TextBox)txtBox).Text.ToString());
                                }
                                else
                                {
                                    //error---------------------------------------
                                }
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 2:
                            if (((TextBox)txtBox).Text == "")
                            {
                                if (_business.IsValidPhone(((TextBox)txtBox).Text.ToString()))
                                {
                                    input[i2] = (((TextBox)txtBox).Text.ToString());
                                }
                                else
                                {
                                    //error---------------------------------------
                                }
                            }
                            else
                            {
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;
                    }
                }


                string sortingPar1 = string.Format(" WHERE Department_ID = {0}", GetDataIDs()[i]);
                List<DepartmentCode> CurrentDepartment = new List<DepartmentCode>();
                CurrentDepartment = _business.GetDepartments(sortingPar1);

                //hospitalID krijgen van de current row in de gridvieuw
                int hospitalID = CurrentDepartment[0].HospitalID;
                string ddName = "ddEdit" + i.ToString() + 0.ToString();
                var dd = container.FindControl(ddName) as DropDownList;

                UserCode LoginUser = (UserCode)Session["authenticatedUser"];
                UserCode user = GetCurrentUser(LoginUser.ID);

                DateTime dt = DateTime.Now;
                string dateNow = dt.ToString("yyyy-MM-dd");

                _business.UpdateDepartment(new DepartmentCode(ListDataIDs[i], input[0], input[1], input[2], Convert.ToInt16(dd.SelectedValue), user.ID, Convert.ToDateTime(dateNow), Convert.ToDateTime(dateNow)));
                track1:
                continue;
            }
        }

        public void SetDropdownContent()
        {
            List<List<string>> ListContentHospital = _business.GetHospitalDropDownContent();
            List<string> names = new List<string>();

            for (int i = 0; i <= 9; i++)
            {
                string ddEdit = "ddEdit" + i.ToString() + "0";
                var container = Master.FindControl("Body");
                var DropDownData = container.FindControl(ddEdit) as DropDownList;

                if (i == 0)
                {
                    for (int i2 = 0; i2 < ListContentHospital.Count; i2++)
                    {
                        names.Add(ListContentHospital[i2][1]);
                    }
                }

                DropDownData.DataSource = names;
                DropDownData.DataBind();
                for (int i2 = 0; i2 < ListContentHospital.Count; i2++)
                {
                    DropDownData.Items[i2 + 1].Value = ListContentHospital[i2][0];
                }
            }
        }


        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Site/DepartmentPage.aspx");
        }

        protected void BtnSaveAndExit_Click(object sender, EventArgs e)
        {
            if (GetDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
            }
            Response.Redirect("../Site/DepartmentPage.aspx");
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (GetDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
                Response.Redirect("../SiteEdit/DepartmentPageEdit.aspx");
            }
        }

	}
}