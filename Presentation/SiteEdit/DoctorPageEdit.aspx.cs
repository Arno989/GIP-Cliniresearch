﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Domain.Business;
using MySql.Data.MySqlClient;

namespace Presentation.SiteEdit
{
	public partial class DoctorPageEdit: System.Web.UI.Page
	{
		private BusinessCode _business = new BusinessCode();
		
		private void sendData()
		{
            List<List<string>> ListContentHospital = _business.GetHospitalDropDownContent();
            for (int i = 0; i <= 9; i++)
			{
                var container = Master.FindControl("Body");
                string[] input = new string[10];
                //int Hospital_ID;

				for (int i2 = 0; i2 <= 9; i2++)
				{
					string tbName = "tbEdit" + i.ToString() + i2.ToString();
					var txtBox = container.FindControl(tbName);

					switch (i2)
					{
						case 0:
							if (((TextBox) txtBox).Text != "")
							{
								input[i2] = (((TextBox) txtBox).Text.ToString());
							}
							else
							{
								goto track1;
							}
							break;

						case 1:
							if (((TextBox) txtBox).Text == "")
							{
								if (_business.IsValidEmail(((TextBox) txtBox).Text.ToString()))
								{
									input[i2] = (((TextBox) txtBox).Text.ToString());
								}
								else
								{
									//error---------------------------------------
								}
							}
							else
							{
								input[i2] = (((TextBox) txtBox).Text.ToString());
							}

							break;

						case 2:
							if (((TextBox) txtBox).Text == "")
							{
								if (_business.IsValidPhone(((TextBox) txtBox).Text.ToString()))
								{
									input[i2] = (((TextBox) txtBox).Text.ToString());
								}
								else
								{
									//error---------------------------------------
								}
							}
							else
							{
								input[i2] = (((TextBox) txtBox).Text.ToString());
							}
							break;

						case 3:
							if (((TextBox) txtBox).Text == "")
							{
								if (_business.IsValidPhone(((TextBox) txtBox).Text.ToString()))
								{
									input[i2] = (((TextBox) txtBox).Text.ToString());
								}
								else
								{
									//error---------------------------------------
								}
							}
							else
							{
								input[i2] = (((TextBox) txtBox).Text.ToString());
							}
							break;

						case 4:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 5:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 6:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 7:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 8:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;

						case 9:
							input[i2] = (((TextBox) txtBox).Text.ToString());
							break;
					}
                }
                string ddName = "ddEdit" + i.ToString() + "0";
                var dropdownData = container.FindControl(ddName) as DropDownList;
                int index = dropdownData.SelectedIndex;

                _business.SetDoctor(input[0],input[1],input[2],input[3],input[4],input[5],input[6],input[7],input[8],input[9]);
                DoctorCode LastItem = _business.GetDoctors().Last();
                _business.addHospitalToDoctor(Convert.ToInt16(ListContentHospital[index -1][0]), LastItem.Doctor_ID);
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
                for(int i2 = 0; i2 < ListContentHospital.Count; i2++)
                {
                    if (i == 0)
                    {
                        names.Add(ListContentHospital[i2][1]);
                    }
                    else
                    {
                        goto track1;
                    }
                }
                track1:
                DropDownData.DataSource = names;
                DropDownData.DataBind();
                for (int i2 = 0; i2 < ListContentHospital.Count; i2++)
                {
                    if(i2 < 9)
                    {
                       DropDownData.Items[i2 + 1].Value = ListContentHospital[i2][0];
                    }
                }
            }
        }

		protected void Page_Load(object sender,EventArgs e)
		{
            SetDropdownContent();
        }

		protected void btnExit_Click(object sender,EventArgs e)
		{
			Response.Redirect("../Site/DoctorPage.aspx");
		}

		protected void btnSaveAndExit_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../Site/DoctorPage.aspx");
		}

		protected void btnSave_Click(object sender,EventArgs e)
		{
			sendData();
			Response.Redirect("../SiteEdit/DoctorPageEdit.aspx");
		}
	}
}