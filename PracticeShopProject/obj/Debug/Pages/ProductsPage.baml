   M S B A M L   `   `   `  ����N  JPracticeShopProject, Version=1.2.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PracticeShopProject.PagesPracticeShopProject.Pages  5      ,    &PracticeShopProject.Pages.ProductsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:PracticeShopProject.Pages     5        N� Title$  ProductsPage��5	      .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $	��top=�6.   $
��0 10q�6F   .+�5      �� $��
Поиск��6      TextBlockStyle#��[  6%   $��	20 0 10 0q�6M   $��15(�6`   $��Center=�6n   $��Medium"�6�   �� 5      -   5        $��SearchTextBox��5   j   $	��180��6     TextBoxStyle#��[ 6"   $��Center=�6H   6j   �� 5      $ Vertical=�6   $��Center=�60   $��Center=�6M   $
��15 0q�6h   .+�5      	� -   5        $��DescendingSortButton��5   H     RadioButtonStyle#��[ 6   .��5      �� $��По убыванию��6    $��15(�63   $��
ExtraLight"�6A   5      	� 5      -   5        $��AscendingSortButton��5   I   #��[ 6   .��5      �� $!��По возрастанию��6    $��15(�66   $��
ExtraLight"�6D   5      5      5      ]� 5   
   $��20 60 20 20q�6   $
��auto��6)   .+�5      �� -   5         ��Name$ ListViewProducts��5      
���  ����5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 ���� 67   �� 5       � �� 5      �� 5   "    �� 
TargetType" ��62   .R�5    &   �� 5!   #   5#      5$      ��5&      �� 5'      .R�5(      �  � Orientation$ 
Horizontal=�6$   $	��Top=�6=   $
��1190��6U   5)      ��5+      �� 5,      .R�5-      �� $��ProductBorder��6U   $��10q�6!   $	��135��6-    � Cursor$
 Hand��69   $
��auto��6G   ._�5.      �� $��Center=�6)   $��Center=�6F   .+�5/   "   �� $	��175��6,   
�������$��0 0 0 10q�6F   �� 50   "   #��[  6r   $	��135��6�   $
��Wrap=�6�   	 �� TextAlignment$	 Center=�6�   $��17(�6�   $��Franklin Gothic Medium)�6�   ��6-   �� *Price+
 �� StringFormat$
 c�� �� ConverterCulture$ ru_Ru��6�   �� 51   "   $��15(�6C   $	��135��6Q   $	 Center=�6]   #��[  6t   $
��Wrap=�6�   ��6-   �� *Name+6�   52      53      54      56      57      58      59      