<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Careers1.aspx.cs" Inherits="Careers1" %>


  <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
    <!DOCTYPE html
      PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head>

      <title>CIS : Careers</title>
      <meta name="viewport" content="width=device-width, initial-scale=1.0">
      <link rel="icon" href="images/favicon.png" type="image/x-icon">
    <!-- StyleSheet CDN -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.7.0/animate.min.css">
    <!-- Bootstrap CSS  -->
    <link rel="stylesheet" href="vendor/css/bootstrap.min.css">
    <!-- jQuery UI CSS -->
    <link rel="stylesheet" href="css/main.min.css">
    <!-- Google CSS -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
      <style type="text/css">
        #loader {
          display: none;
        }

        #blur {
          width: 100%;
          position: fixed;
          z-index: 99;
          top: 0px;
          left: 0px;
          background-color: #FFFFFF;
          width: 100%;
          height: 100%;
          filter: Alpha(Opacity=70);
          opacity: 0.70;
          -moz-opacity: 0.70;
        }

        #progress {
          z-index: 500;
          top: 60%;
          left: 50%;
          position: absolute;
          padding: 5px 5px 5px 5px;
          text-align: center;

        }

        .careerHeader a.navbar-brand {
          display: block;
          width: 150px;
          margin: 0 auto 20px;
        }

        .careerHeader {
          margin-top: 20px;
        }

        .hdwrapper {
          background: #f6f6f6;
          padding: 4rem 0;
          margin-bottom: 3rem;
        }

        .hdwrapper h2 {
          margin-bottom: 0;
        }

        .career-area {
          margin-top: 4rem;
        }

        input[type="checkbox"] {
          border: 0px;
          width: 1.5em;
          height: 1.5em;
          margin-right: 6px;
          vertical-align: middle;
          color: rgba(63, 103, 111, 0.8);


        }

        .career-form-area label,
        .career-form-area .was-validated .form-check-input:invalid~.form-check-label,
        .career-form-area .was-validated .form-check-input:valid~.form-check-label {
          color: rgba(63, 103, 111, 0.8);
          font-size: 1.6rem;
        }





        span.brnch {
          display: block;
          font-size: 12px;
          width: max-content;
          padding: 20px 8px;
          position: relative;
          font-style: italic;
          /* border-left: 2px solid;
          border-right: 2px solid; */
          border-radius: 30px;
          line-height: 1.2;
          font-weight: normal;
      </style>
    </head>

    <body>
      <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>

            <%-- <div id="header"></div> --%>
              <%-- <section class="careerHeader">
                <div class="container">
                  <a class="navbar-brand" href="https://ciseducation.org/index.aspx">
                    <img src="images/cis-Logos.png" alt="" class="img-fluid">
                  </a>
                </div>
                </section>--%>
                <%--<div class="container careerbtb">
                  <a href="https://ciseducation.org/index.aspx" class="global-btn-two">back to home
                    &nbsp;<span>+</span></a>
                  </div>--%>
                  <div id="loader">
                    <%-- <div class="loader-spinner">
                      <img src="images/loader.gif" alt="">
                  </div>--%>
                  </div>
                  <main>
                    <!-- <section class="inner-hero-section" style="background-image: url(https://subharti.org/includes/assets/images/5.jpg);">
        <div class="container">
          <h1 class="hero-primary-heading">Careers</h1>
        </div>
      </section> -->
                    
                    <section class="reinforcing-habits">
                      <div class="container">
                        <div class="career-form-area">
                          <div class="container">
                            <div class="row">
                              <div class="form-items">

                                <div class="form-label">
                                  Personal Information:
                                </div>
                                <br />
                                <div class="row">

                                  <div class="col-md-6">

                                    <asp:TextBox ID="txtFullName" runat="server" placeholder="Full Name"
                                      CssClass="form-control">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                      ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFullName"
                                      SetFocusOnError="true" ValidationGroup="A"></asp:RequiredFieldValidator>
                                  </div>

                                  <div class="col-md-6">

                                    <asp:TextBox ID="txtEmail" runat="server" placeholder="E-mail Address"
                                      CssClass="form-control">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                      ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail"
                                      SetFocusOnError="true" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                      ErrorMessage="Invalid Email!" ControlToValidate="txtEmail" SetFocusOnError="true"
                                      ValidationGroup="A"
                                      ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                      ForeColor="Red"></asp:RegularExpressionValidator>
                                  </div>
                                </div>

                                <div class="row">

                                  <div class="col-md-6">

                                    <asp:TextBox ID="txtMobile" runat="server" placeholder="Mobile Number"
                                      CssClass="form-control"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                      ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMobile"
                                      SetFocusOnError="true" ValidationGroup="A"></asp:RequiredFieldValidator>
                              <ajaxToolkit:FilteredTextBoxExtender ID="txtMobile_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" FilterType="Numbers" TargetControlID="txtMobile">
                                </ajaxToolkit:FilteredTextBoxExtender>

                                  </div>
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtAddress" runat="server" placeholder="Address"
                                      CssClass="form-control">
                                    </asp:TextBox>

                                  </div>

                                </div>

                                <div class="row">
                                  <div class="col-md-4">

                                    <asp:DropDownList ID="drpCountry" runat="server" CssClass="form-select"
                                      AutoPostBack="True" onselectedindexchanged="drpCountry_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                      ErrorMessage="*" ForeColor="Red" ControlToValidate="drpCountry"
                                      SetFocusOnError="true" ValidationGroup="A" InitialValue="0">
                                    </asp:RequiredFieldValidator>

                                  </div>
                                  <div class="col-md-4">

                                    <asp:DropDownList ID="drpState" runat="server" AutoPostBack="True"  CssClass="form-select"
                                      onselectedindexchanged="drpState_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                      ErrorMessage="*" ForeColor="Red" ControlToValidate="drpState"
                                      SetFocusOnError="true" ValidationGroup="A" InitialValue="0">
                                    </asp:RequiredFieldValidator>
                                  </div>
                                  <div class="col-md-4">

                                    <asp:DropDownList ID="drpCity" runat="server"  CssClass="form-select"
                                      AutoPostBack="True">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                      ErrorMessage="*" ForeColor="Red" ControlToValidate="drpCity"
                                      SetFocusOnError="true" ValidationGroup="A" InitialValue="0">
                                    </asp:RequiredFieldValidator>
                                  </div>

                                </div>

                                <div class="form-label">
                                  Educational Qualifications:
                                </div>

                                <div class="row">

                                  <div class="col-md-6">

                                    <asp:DropDownList ID="drpHighestQuali" runat="server" class="form-select">
                                      <asp:ListItem>Highest Degree Earned</asp:ListItem>
                                      <asp:ListItem>Bachelor's</asp:ListItem>
                                      <asp:ListItem>PhD</asp:ListItem>
                                      <asp:ListItem>Others</asp:ListItem>

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                      ErrorMessage="*" ForeColor="Red" ControlToValidate="drpHighestQuali"
                                      SetFocusOnError="true" ValidationGroup="A" InitialValue="0">
                                    </asp:RequiredFieldValidator>
                                  </div>

                                  <div class="col-md-6">

                                    <asp:TextBox ID="txtMajorFieldStudy" runat="server" class="form-control"
                                      placeholder="Major/Field of Study"></asp:TextBox>
                                  </div>
                                </div>

                                <div class="row">
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtNameOfInsitution" runat="server" class="form-control"
                                      placeholder="Name of Institution"></asp:TextBox>
                                  </div>
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtYearOfPassing" runat="server" class="form-control"
                                      placeholder="Year of Passing out"></asp:TextBox>
                                       <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    Enabled="True" FilterType="Numbers" TargetControlID="txtYearOfPassing">
                                </ajaxToolkit:FilteredTextBoxExtender>
                                  </div>
                                </div>

                                <div class="form-label">
                                  Last / Current Teaching Experience:
                                </div>
                                <div class="row">
                                  <div class="col-md-12">
                                    <span class="brnch"> Tick All that Apply:Experience you have had in:</span>
                                  </div>
                                  <div class="col-md-12" style="padding-left:20px">

                                    <asp:CheckBoxList ID="chkTick" runat="server" RepeatDirection="Horizontal"
                                      RepeatColumns="1" RepeatLayout="Flow" ForeColor="#333">
                                      <asp:ListItem>Teaching</asp:ListItem>
                                      <asp:ListItem>Content Development</asp:ListItem>
                                      <asp:ListItem>Instructional Designing</asp:ListItem>
                                      <asp:ListItem>Others </asp:ListItem>
                                    </asp:CheckBoxList>

                                  </div>

                                </div>

                                <div class="row">
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtSchoolOrganization" runat="server" class="form-control"
                                      placeholder="School / Organization Name">
                                    </asp:TextBox>


                                  </div>
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtPositionHeld" runat="server" class="form-control"
                                      placeholder="Position Held">
                                    </asp:TextBox>

                                  </div>
                                </div>

                                <div class="row">
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtSubjectTaught" runat="server" class="form-control"
                                      placeholder="Subject(s) Taught">
                                    </asp:TextBox>


                                  </div>
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtGrades" runat="server" class="form-control"
                                      placeholder="Grades Taught">
                                    </asp:TextBox>

                                  </div>
                                </div>



                                <div class="row">
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtDuration" runat="server" class="form-control"
                                      placeholder="Duration of Employment (Start Date - End Date)"></asp:TextBox>


                                  </div>
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtTotalWorkExp" runat="server" class="form-control"
                                      placeholder="Total Work Experience (in Years & Months)"></asp:TextBox>

                                  </div>
                                </div>
                                <div class="form-label">
                                  Certifications:
                                </div>



                                <div class="row">
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtTeachingCertificate" runat="server" class="form-control"
                                      placeholder="Teaching Certificate(s)"></asp:TextBox>


                                  </div>
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtSpecialized" runat="server" class="form-control"
                                      placeholder="Specialized Training (e.g., Special Education, ESL)"></asp:TextBox>

                                  </div>
                                </div>

                                <div class="row">
                                  <div class="col-md-12">
                                    <asp:TextBox ID="txtSkillsCompeten" runat="server" class="form-control"
                                      placeholder="Skills and Competencies:" TextMode="MultiLine" Rows="5">
                                    </asp:TextBox>


                                  </div>

                                </div>


                                <div class="form-label">
                                  Professional References 1:
                                </div>

                                <div class="row">
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtProfessionalName" runat="server" class="form-control"
                                      placeholder="Name">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                      ErrorMessage="*" ForeColor="Red" ControlToValidate="txtProfessionalName"
                                      SetFocusOnError="true" ValidationGroup="A"></asp:RequiredFieldValidator>

                                  </div>
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtRelationShip" runat="server" class="form-control"
                                      placeholder="Relationship to Applicant"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                      ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRelationShip"
                                      SetFocusOnError="true" ValidationGroup="A"></asp:RequiredFieldValidator>
                                  </div>
                                </div>


                                <div class="row">
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtPreofessPhoneNo" runat="server" class="form-control"
                                      placeholder="Phone Number">
                                    </asp:TextBox>
                                    
                                       <ajaxToolkit:FilteredTextBoxExtender ID="txtContact_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" FilterType="Numbers" TargetControlID="txtPreofessPhoneNo">
                                </ajaxToolkit:FilteredTextBoxExtender>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                      ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPreofessPhoneNo"
                                      SetFocusOnError="true" ValidationGroup="A"></asp:RequiredFieldValidator>


                                  </div>
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtProfessEmail" runat="server" class="form-control"
                                      placeholder="Email">
                                    </asp:TextBox>

                                  </div>
                                </div>


                                  <div class="form-label">
                                  Professional References 2:
                                </div>

                                <div class="row">
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtProfessionalName1" runat="server" class="form-control"
                                      placeholder="Name">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                      ErrorMessage="*" ForeColor="Red" ControlToValidate="txtProfessionalName1"
                                      SetFocusOnError="true" ValidationGroup="A"></asp:RequiredFieldValidator>

                                  </div>
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtRelationShip1" runat="server" class="form-control"
                                      placeholder="Relationship to Applicant"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                      ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRelationShip1"
                                      SetFocusOnError="true" ValidationGroup="A"></asp:RequiredFieldValidator>
                                  </div>
                                </div>


                                <div class="row">
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtPreofessPhoneNo1" runat="server" class="form-control"
                                      placeholder="Phone Number">
                                    </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server"
                                      ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPreofessPhoneNo1"
                                      SetFocusOnError="true" ValidationGroup="A"></asp:RequiredFieldValidator>

                                          <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    Enabled="True" FilterType="Numbers" TargetControlID="txtPreofessPhoneNo1">
                                </ajaxToolkit:FilteredTextBoxExtender>


                                  </div>
                                  <div class="col-md-6">
                                    <asp:TextBox ID="txtProfessEmail1" runat="server" class="form-control"
                                      placeholder="Email">
                                    </asp:TextBox>

                                  </div>
                                </div>

                                <div class="form-label">
                                  Write about your special strengths as an Educator:
                                </div>

                                <div class="row">
                                  <div class="col-md-12">
                                    <asp:TextBox ID="txtSpecialStrenths" runat="server" class="form-control"
                                      TextMode="MultiLine" Rows="40" placeholder="Special Strengths "></asp:TextBox>
                                  </div>
                                </div>
                                <br />

                                <div class="form-label">
                                  Upload Your Resume( Only PDF format allowed):
                                </div>

                                <div class="row">
                                  <div class="col-md-12">
                                    <asp:FileUpload ID="FileUpload1" runat="server" width="600" size="81">
                                    </asp:FileUpload>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                      ErrorMessage="*" ForeColor="Red" ControlToValidate="FileUpload1"
                                      SetFocusOnError="true" ValidationGroup="A"></asp:RequiredFieldValidator>
                                     
                                  </div>
                                </div>



                                <div class="form-button mt-5 text-center">
                              

                                  <asp:Button ID="Button1" runat="server" Text="Submit" class="global-btn-two"
                                    ValidationGroup="A" onclick="Button1_Click"></asp:Button>
                                    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                                </div>

                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </section>
                  </main>

          </ContentTemplate>

            <Triggers>  
  
         <asp:PostBackTrigger ControlID="Button1" />  
  
</Triggers>  
        </asp:UpdatePanel>

        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
          <ProgressTemplate>
            <div id="blur">
              &nbsp;</div>
            <div id="progress">
              <img alt="" src="images1/ajax-loader.gif" />
            </div>
          </ProgressTemplate>
        </asp:UpdateProgress>
        <div id="footer"></div>

        <%-- <script src="vendor/js/jquery.min.js"></script>--%>

          <script src="vendor/js/bootstrap.min.js"></script>

          <%-- <script src="vendor/js/owl.carousel.min.js"></script>--%>

            <%-- <script src="js/main.js"></script>--%>
              <script>
                // Navbar

                (function ($) {
                  $(function () {

                    $('#navbar-toggle').click(function () {
                      $('nav ul').slideToggle();
                    });

                    $('#navbar-toggle').on('click', function () {
                      this.classList.toggle('active');
                    });

                    $('nav ul li a:not(:only-child)').click(function (e) {
                      $(this).siblings('.navbar-dropdown').slideToggle("slow");

                      $('.navbar-dropdown').not($(this).siblings()).hide("slow");
                      e.stopPropagation();
                    });

                    $('html').click(function () {
                      $('.navbar-dropdown').hide();
                    });
                  });
                })(jQuery);

              </script>

      </form>


    </body>

    </html>