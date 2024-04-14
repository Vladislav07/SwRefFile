using EPDM.Interop.epdm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Reference
{
  public partial class Form1 : Form
  {
        public Form1()
    {
        InitializeComponent();
    }

    IEdmVault5 vault1 = null;

    public void FileReferencesCSharp_Load(System.Object sender, System.EventArgs e)
    {

        try
        {
            IEdmVault5 vault1 = new EdmVault5();
            IEdmVault8 vault = (IEdmVault8)vault1;
            EdmViewInfo[] Views = null;

            vault.GetVaultViews(out Views, false);
            VaultsComboBox.Items.Clear();
            foreach (EdmViewInfo View in Views)
            {
                VaultsComboBox.Items.Add(View.mbsVaultName);
            }
            if (VaultsComboBox.Items.Count > 0)
            {
                VaultsComboBox.Text = (string)VaultsComboBox.Items[0];
            }
        }
        catch (System.Runtime.InteropServices.COMException ex)
        {
            MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + "\n" + ex.Message);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public void BrowseButton_Click(System.Object sender, System.EventArgs e)
    {
        try
        {
            CustRefListBox.Items.Clear();

            //Only create a new vault object
            //if one hasn't been created yet
            if (vault1 == null)
                vault1 = new EdmVault5();
            if (!vault1.IsLoggedIn)
            {
                //Log into selected vault as the current user
                vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
            }

            //Set the initial directory in the File Open dialog
            CustRefOpenFileDialog.InitialDirectory = vault1.RootFolderPath;
            //Show the File Open dialog
            System.Windows.Forms.DialogResult DialogResult = default(System.Windows.Forms.DialogResult);
            DialogResult = CustRefOpenFileDialog.ShowDialog();
            //If the user didn't click Open, exit the sub
            if (!(DialogResult == System.Windows.Forms.DialogResult.OK))
                return;

             foreach (string FileName in CustRefOpenFileDialog.FileNames)
            {
                CustRefListBox.Items.Add(FileName);
            }
        }
        catch (System.Runtime.InteropServices.COMException ex)
        {
            MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + "\n" + ex.Message);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }


    public void AddCustomFileReference_Click(System.Object sender, System.EventArgs e)
    {
        try
        {
            //Only create a new vault object
            //if one hasn't been created yet
            IEdmVault7 vault2 = null;
            if (vault1 == null)
                vault1 = new EdmVault5();
            vault2 = (IEdmVault7)vault1;
            if (!vault1.IsLoggedIn)
            {
                //Log into selected vault as the current user
                vault1.LoginAuto(VaultsComboBox.Text, this.Handle.ToInt32());
            }

            IEdmAddCustomRefs addCustRefs = (IEdmAddCustomRefs)vault2.CreateUtility(EdmUtility.EdmUtil_AddCustomRefs);
            Int32[] ppoFileIdArray = new Int32[CustRefListBox.Items.Count];
            IEdmFile5 file = null;
            IEdmFolder5 parentFolder = null;
            int i = 0;
            foreach (string FileName in CustRefListBox.Items)
            {
                file = vault2.GetFileFromPath(FileName, out parentFolder);
                if (!file.IsLocked)
                {
                    file.LockFile(parentFolder.ID, this.Handle.ToInt32(), (int)EdmLockFlag.EdmLock_Simple);
                }
                ppoFileIdArray[i] = file.ID;
                i++;
            }
            Boolean retCode = false;

            //Add the file that is copied to the clipboard as a custom reference to the selected file
            foreach (int ID in ppoFileIdArray)
            {
                addCustRefs.AddReferencesClipboard(ID);
                addCustRefs.CreateTree((int)EdmCreateReferenceFlags.Ecrf_Nothing);
                addCustRefs.ShowDlg(this.Handle.ToInt32());
                retCode = addCustRefs.CreateReferences();
            }

            // Check in the file
            file.UnlockFile(this.Handle.ToInt32(), "Custom reference added");

            //Display current custom file references
            retCode = addCustRefs.ShowEditReferencesDlg(ref ppoFileIdArray, this.Handle.ToInt32());

        }
        catch (System.Runtime.InteropServices.COMException ex)
        {
            MessageBox.Show("HRESULT = 0x" + ex.ErrorCode.ToString("X") + "\n" + ex.Message);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

}
}
