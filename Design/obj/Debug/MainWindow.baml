   M S B A M L   `   `   `  ����A  =Design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DesignDesign  5   	   )clr-namespace:Design.myUCDesign.myUC  5   	       Design.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Design     5   	   (ucclr-namespace:Design.myUC     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ 
MainWindow��5   	   $	��600��6   $
��1000��6)    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    
 MainVM � DataContext# [ 5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5'      � 
������� � RowDefinitions 5*   
   �� 5+      $
��auto �6   5-      �� 5.      .+�50   
   � $��0��6   .+�51         Design.myUC.CtrlBarUC  52      � 54   
   $��1��6    � 	Resources 55      	 �� 
TargetType # MaterialDesignRaisedLightButton
 �� BasedOn �� Property �� Value��%]   '��       7  �� 56      "	 ��6   8
   .�57      ��  � ��
 �����63   58      59       � ColumnDefinitions 5:      �� 5;      $	��150 �6#   �� 5<      .+�5@      �� $��1��6   ��6-   �� #  MaterialDesignThemes.Wpf.Card  5A      $��0��6"   $��	0,0,2.4,0q�62   $	��308��6E   .��5B      �� $��5q�6   .+�5C      �� $��Danh Sách các bảng��6    $��50��6:   �� 5D      -   5         ��Name$ 
btnProduct��5D      {�.  � ToolTip$# Xem thông tin bảng Product��5E      .��6B   	Product5G      �� 5H      -   5        $ btnCategory��5H      $$ Xem thông tin bảng Category��5I      .��6;   
Category5K      �� 5L      -   5        $ btnTransaction��5L      $, &Xem thông tin bảng Transaction data��5N      .��6C   Transaction5P      �� 5Q      $"��Thống kê và biểu đồ��6    $��0 20 0 0q�6;   �� 5R      -   5        $ 	btnStatis��5R      $��
statistics��60   6E   �� 5U      -   5        $ btnNewChart��5U      $��Coming soon...��62   $��0 50 0 0q�6e   5W      5X      5Z      5\      5^      