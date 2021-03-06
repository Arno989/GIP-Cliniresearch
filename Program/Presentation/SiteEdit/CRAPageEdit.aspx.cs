﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;

namespace Presentation.SiteEdit
{
	public partial class CRAPageEdit: System.Web.UI.Page
	{
        private BusinessCode _business = new BusinessCode();

        private List<List<string>> GetSessionData()
        {
            return (List<List<string>>)Session["ListDataSession"];
        }

        private List<int> GetSessionDataIDs()
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
            if (!IsPostBack)
            {
                List<List<string>> ListData = GetSessionData();
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
            List<List<string>> ListData = GetSessionData();
            int Count = 0;
            for (int i = 0; i < ListData.Count; i++)
            {
                for (int i2 = 0; i2 <= 4; i2++)
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

                        case 3:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;

                        case 4:
                            ((TextBox)txtBox).Text = ListData[i][Count].Replace("&nbsp;", "");
                            break;
                    }
                    Count++;
                }
            }
        }

        private void SendData()
        {
            for (int i = 0; i < 10; i++)
            {
                var container = Master.FindControl("Body");
                string[] input = new string[10];

                for (int i2 = 0; i2 <= 4; i2++) //--Var
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
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 2:
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

                        case 3:
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

                        case 4:
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

                UserCode LoginUser = (UserCode)Session["authenticatedUser"];
                UserCode user = GetCurrentUser(LoginUser.ID);

                DateTime dt = DateTime.Now;
                string dateNow = dt.ToString("yyyy-MM-dd");

                _business.AddCRA(new CRACode(0, input[0], input[1], input[2], input[3], input[4], user.ID, Convert.ToDateTime(dateNow), Convert.ToDateTime(dateNow))); //--Var

                track1:
                continue;
            }
        }

        private void UpdateData()
        {
            List<int> ListDataIDs = GetSessionDataIDs();

            for (int i = 0; i < ListDataIDs.Count; i++)
            {
                var container = Master.FindControl("Body");
                string[] input = new string[10];

                for (int i2 = 0; i2 <= 4; i2++) //--Var
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
                                input[i2] = (((TextBox)txtBox).Text.ToString());
                            }
                            break;

                        case 2:
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

                        case 3:
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

                        case 4:
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

                UserCode LoginUser = (UserCode)Session["authenticatedUser"];
                UserCode user = GetCurrentUser(LoginUser.ID);

                DateTime dt = DateTime.Now;
                string dateNow = dt.ToString("yyyy-MM-dd");

                _business.UpdateCRA(new CRACode(ListDataIDs[i], input[0], input[1], input[2], input[3], input[4], user.ID, Convert.ToDateTime(dateNow), Convert.ToDateTime(dateNow))); //--Var

                track1:
                continue;
            }
        }


        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Site/CRAPage.aspx"); //--Var
        }

        protected void BtnSaveAndExit_Click(object sender, EventArgs e)
        {
            if (GetSessionDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
            }
            Response.Redirect("../Site/CRAPage.aspx");  //--Var
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (GetSessionDataIDs() != null)
            {
                UpdateData();
            }
            else
            {
                SendData();
                Response.Redirect("../SiteEdit/CRAPageEdit.aspx");  //--Var
            }
        }
	}
}