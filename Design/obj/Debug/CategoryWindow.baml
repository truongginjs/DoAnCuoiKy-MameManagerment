   M S B A M L   `   `   `  ����A  =Design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DesignDesign  5          Design.CategoryWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:Design     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         CategoryVMUC  � DataContext#  [  5        MaterialDesignBody#���  5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      �� 5      $	��250 �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��0��6   $��0q�6.   $��Stretch=�69   .��5      �  � RowDefinitions 5      �� 5      $
��auto �6$   �� 5      .+�5      ]� .+�5      �� $��0��6!    �� Orientation$ 
Horizontal=�6.   $��Right=�6G   .+�5       ��  � ToolTip$
 Xóa��6C   
������ 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6i   ��6!   �� *DeleteCommand+.��5!      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Delete=�66   5"      �� 5)      -   5         ��Name$ 	btnImport��5)   !   $ thêm từ Excel��6L   
������#��[ 6|   .��5*        $ Numeric9PlusBoxOutline=�66   5+      5-      �� 5/      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Tìm kiếm��50      $	��200��6G   $
��Left=�6S   $��10 0 0 0q�6n    % !MaterialDesignFloatingHintTextBox#��[ 51      ��5/      �� *SearchCommand+
 �� UpdateSourceTrigger$
 PropertyChanged=�51      53      �� 54      $
��Auto=�6   $��1��6B   .��55      �� $	��410��6�   ��6   �� *ListCategory+ �� SelectedItem 6D   �� *SelectedCategory+ �� Mode$ OneWayToSource=� �� View 56      �� 57      .P�58   "   �� $
��Name��61    �� DisplayMemberBinding 6?   �� *Name+6g   �� 59   "   $��Detail��61    6A   �� *Detail+6k   5;      5=      5>      5@      5B        5D   
   $��1��6   $��	0.6,0,0,0q�6/   $	��321��6B   .��5E      �� $��5 0 0 0q�6    � 	Resources 5G       �� 
TargetType �� Property �� Value  
khoangCach��%�   '��       &	 N     �� 5H      " ��6   .�5I      ��  � ��$ 0 2 10 2q�63   5J      �� 5K      " ��6   .�5L      ��  � ��$ 0 0 0 8q�63   5M      5N      .+�5O      �� $��Thêm��6   $��5 0 0 50q�6)   $��Center=�6;   �� 5P      $ 
Horizontal=�6   #��[ 66   .+�5Q      �� $��Name:��6    $��Center=�6-   �� 5R      $	��138��6f   $	 Nhập tên danh mục��6r   ��6   �� *Name+$
 PropertyChanged=�$ TwoWay=�6r   5S      �� 5T      $ 
Horizontal=�6   #��[ 66   .+�5U      �� $��Detail:��6    $	��Top=�6/   �� 5V       �� TextWrapping$
 Wrap=�5W      $	��180��5X       �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�5Z      $	��Top=�5[      $	 Thông tin thêm��5\      $��80��5]      ��5V      �� *Detail+$ TwoWay=�.��5]   %   5^      5_      �� 5c      -   5         ��Name$ 	tbWarning��5c      $6��0*Bạn vui lòng điền đầy đủ thông tin��6/   
���  ��$��	ExtraBold"�6k   $y�Hidden=�6�   �� 5e      $ 
Horizontal=�6   $��Center=�66   $��	0 50 0 50q�6S   .+�5f      �� $	��100��6=   ��6   �� *EditCommand+��6I   �� *
TextButton+$
 PropertyChanged=���5g      �� 5h      " ��6$    �� BasedOn# [B��6A    �� Triggers 5i   "   �� 5j   &    �� Binding 62   ��  �� ElementName$ txtName�� �� Path$ Text.Length� �� Value 06l   .a�5k   *   ��  � {� .  6F   5l   '   5t      5w      �� 5y      $��Clear��6B   $	��100��6R   $��30 0 0 0q�6^   ��6   �� *ClearFormCommand+��5z      �� 5{      " ��6$   # [B��68    5|   "   ^� 5}   &    ^� 
Conditions 5~   *   �� 5   .    �� Binding 68   �� *Text.Length+$ txtName�� �� Value 06m   0�5�   *   �� 5�   .    � {� .  6J   5�   '   5�      5�      5�      5�      5�      5�      5�      