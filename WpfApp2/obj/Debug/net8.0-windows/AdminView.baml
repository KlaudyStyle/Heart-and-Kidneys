   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfApp2.ViewModelsWpfApp2.ViewModels  5          WpfApp2.Views.AdminView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /vm clr-namespace:WpfApp2.ViewModels     5        � DataContext  5      '   !WpfApp2.ViewModels.AdminViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��5q�6;   .+�5      �� $��Добавить��6   $��80��6K   $��5q�6V   ��6(   �� *AddUserCommand+6V   �� 5      $��Удалить��6   $��80��5      $��5q�6    ��5      �� *DeleteUserCommand+��5      ��  �� ElementName$ 	usersGrid�� �� Path$ SelectedItem�5       �� 5      $	��120��5      $��5q�6#   ��5      �� *Roles+ �� SelectedItem 5      �� *SelectedRole+5   #   �� 5      $��Сохранить��6   $��80��6I   $��5q�6T   ��6)   �� *SaveCommand+6T   5       &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ 	usersGrid��5"      $��1��6&      AutoGenerateColumns$ False��5$         CanUserAddRows$ False��5%      ��5#      �� *Users+	   Columns	 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Логин��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *
Username+6Q     5(      $
 Пароль��6%   $ * 6R    65   �� *
Password+6R   4  .System.Windows.Controls.DataGridComboBoxColumn  5)      $
 Роль��5*         DisplayMemberPath$ .��5-         SelectedValuePath$ .��5.      $	 120 5/         ItemsSource 5+      �� *DataContext.Roles+ �� RelativeSource ��  �� AncestorType UserControl   SelectedValueBinding 5,      �� *Role+ �� UpdateSourceTrigger$ PropertyChanged=�5/      4  .System.Windows.Controls.DataGridCheckBoxColumn  50      $
 Активен��6)   $ 80 6W    6:   �� *
IsActive+6W   52      �� 54   
   $��2��6   .@�55      �� ��6   �� *Users.Count+ �� StringFormat$0 *Всего пользователей: {0}��56      57      58      