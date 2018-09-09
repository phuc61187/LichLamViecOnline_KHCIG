<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="demoWizard.aspx.cs" Inherits="Demo.demoWizard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Wizard ID="Wizard1" runat="server">
            <WizardSteps>
                <asp:WizardStep runat="server" title="Step 1">
                </asp:WizardStep>
                <asp:WizardStep runat="server" title="Step 2">
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
    </form>
</body>
</html>
