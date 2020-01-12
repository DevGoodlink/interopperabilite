<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="interroperabilite._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <h2>Excel</h2>
            <p>
                Importe les données depuis un fichier excel et les enregistre sur une base de données SQL Server à l'aide d'entity framework en utilisant un modèle de données.
            </p>
            <p>
                <asp:Button runat="server" CssClass="btn btn-primary"  text="Importer" OnClick="LoadFromExcel_Click"/>
            </p>
        </div>
    </div>
    <div class="row">
        <asp:GridView ID="Notes" runat="server" AutoGenerateColumns="True">
            
            
        </asp:GridView>
    </div>
</asp:Content>
