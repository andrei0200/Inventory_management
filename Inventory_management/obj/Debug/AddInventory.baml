   M S B A M L   `   `   `  ����L  HInventory_Manager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Inventory_ManagerInventory_Manager  5   	   $    Inventory_Manager.AddInventory   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Inventory_Manager     5   	     � Title$  AddInventory��5   	   $	��379��6   $	��568��6+    � WindowStartupLocation$ CenterScreen=�67    � Icon$ 	/icon.png��6\   .��5	      � .+�5
   
   �� $-��'Completati inventarul pentru angajatul ��6   $
��Left=�6B   $��
22,108,0,0q�6]   $	��Top=�6q   $	��378��6�   $��18(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ 
utilizator��5      $�� ��6$   $
��Left=�6/   $��369,108,0,0q�6J   $	��Top=�6_   $��18(�6w   $
��Bold"�6�   $	��184��6�   $��Normal$�6�   �� 5   
   $��Nume  ->��6   $
��Left=�6&   $��
25,150,0,0q�6A   $	��Top=�6U   $	��107��6m   $
��Bold"�6y   $��16(�6�    J� RenderTransformOrigin$ 0.434,2.047&�6�   �� 5   
   $��Data de expirare ->��6   $
��Left=�61   $��
25,184,0,0q�6L   $	��Top=�6`   $	��162��6x   $
��Bold"�6�   $��16(�6�   �� 5   
   $��Data de fabricatie ->��6   $
��Left=�63   $��
25,217,0,0q�6N   $	��Top=�6b   $	��191��6z   $
��Bold"�6�   $��16(�6�   �� 5   
   $��Numar KG ->��6   $
��Left=�6)   $��
25,250,0,0q�6D   $	��Top=�6X   $	��156��6p   $
��Bold"�6|   $��16(�6�   �� 5   
   $��
Pret/KG ->��6   $
��Left=�6(   $��
25,284,0,0q�6C   $	��Top=�6W   $	��148��6o   $
��Bold"�6{   $��16(�6�   $��32��6�   �� 5   
   -   5        $��Insert��5      $
��Left=�6"   $��313,280,0,0q�6=   $	��Top=�6R   $��88��6j   $��45��6u   $
��Bold"�6�   $��20(�6�   �� 5   
   -   5         ��Name$ in_nume��5      $
��Left=�6#   $��117,154,0,0q�6>   $�� ��6S    �� TextWrapping$
 Wrap=�6[   $	��Top=�6o   $	��150��6�   $��16(�6�   $
��Bold"�6�   $��30��6�   �� 5   
   -   5        $ in_expirare��5      $
��Left=�6'   $��198,187,0,0q�6B   $�� ��6W   $
 Wrap=�6_   $	��Top=�6s   $	��140��6�   $��16(�6�   $
��Bold"�6�   $��30��6�   �� 5   
   -   5        $ in_fabricatie��5      $
��Left=�6)   $��206,221,0,0q�6D   $�� ��6Y   $
 Wrap=�6a   $	��Top=�6u   $	��140��6�   $��16(�6�   $
��Bold"�6�   $��30��6�   �� 5   
   -   5        $ 
in_numarkg��5      $
��Left=�6&   $��156,254,0,0q�6A   $�� ��6V   $
 Wrap=�6^   $	��Top=�6r   $	��100��6�   $��16(�6�   $
��Bold"�6�   $��30��6�   �� 5   
   -   5        $ in_pret��5      $
��Left=�6#   $��138,288,0,0q�6>   $�� ��6S   $
 Wrap=�6[   $	��Top=�6o   $	��100��6�   $��16(�6�   $
��Bold"�6�   $��30��6�   �� 5   
   $��9,-2,24,246q�6   $
��Fill=�6%   $��
image2.png��64   �� 5   
   $
��Left=�6   $	��187��6+   $��401,161,0,0q�68   $	��Top=�6M   $	��143��6e   $��	/addd.png��6q   5      5      