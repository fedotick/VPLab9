   M S B A M L   `   `   `  ����A  =VPLab9, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VPLab9VPLab9  5   	       VPLab9.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:VPLab9     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � Title$
 Toys��5   	   $	��450��6   $	��800��6#    � 
ResizeMode$ NoResize=�5   	    � WindowState$ Normal=�6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   o� $	��Top=�6   
�������.@�5      m� $
��File��6   .@�5      m� -   5        $��Open...��5      6,   m� 5      -   5         m�Name$ menuItemSave��5      $
��Save��61   ${�False��6?   6Q   m� 5      -   5        $ menuItemSaveAs��5      $��
Save as...��63   ${�False��6G   6Y   m� 5      -   5        $
��Exit��5      6)   5      m� 5       $
��Edit��6   .@�5!      m� -   5        $	��Add��5!      6(   5"      m� 5#      $��Chart��6   .@�5$      m� -   5        $ menuItemCreateChart��5$      $��Create chart��68   ${�False��6N   6`   5%      5&      &   System.Windows.Controls.DataGrid  5(   
   -   5          Name$ toysDataGrid��5(      $��1��6)   	   AutoGenerateColumns$	 False��66   
   
IsReadOnly$

 True��6R      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6d      Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+   ElementStyle 5+      �� 5,       �� 
TargetType" ��6    .�5-      ��  �� Property � �� �� Value$ Center=�6B   5.      50        51      $ Manufacturer Country��6%    6C   �� *ManufacturerCountry+ 52      �� 53      " ��6    .�54      ��  � ��$ Center=�6B   55      57        58      $ Price��6%    64   �� *Price+ 59      �� 5:      " ��6    .�5;      ��  � ��$ Center=�6B   5<      5>        5?      $
 Type��6%    63   �� *	TypeOfToy+ 5@      �� 5A      " ��6    .�5B      ��  � ��$ Center=�6B   5C      5E      4  .System.Windows.Controls.DataGridTemplateColumn  5F      $ Image��6)      CellTemplate 5G      �� 5H      .R�5I      �� $	��100��6A   $	��100��6M   $��Uniform=�6Z   $��Center=�6l   ��6$   �� *	ImagePath+6l   5J      5L         ColumnHeaderStyle 5N      �� 5O      =  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5P      ��  � ��$ Center=�6A   5Q       � ContextMenu 5S      �� 5T      -   5         ��Name$ rowContextMenu��5T      .@�5U      m� -	   5        $
��Edit��5U      6-   m� 5V      -
   5        $��Delete��5V      6/   5W      5Y      5Z      5[      