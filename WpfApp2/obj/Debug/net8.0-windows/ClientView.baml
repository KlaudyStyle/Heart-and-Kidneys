   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfApp2.ViewModelsWpfApp2.ViewModels  5          WpfApp2.Views.ClientView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /vm clr-namespace:WpfApp2.ViewModels     5        � DataContext  5      (   "WpfApp2.ViewModels.ClientViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��5q�6;   .+�5      �� $��Добавить��6   $��80��6M   $��5q�6X   ��6(   �� *AddClientCommand+6X   �� 5      $��Удалить��6   $��80��5      $��5q�6    ��5      �� *DeleteClientCommand+��5      ��  �� ElementName$ clientsGrid�� �� Path$ SelectedItem�5       �� 5      $	��200��63   $��5q�6?   ��6   �� *SearchQuery+6?   �� 5      $��
Поиск��6   $��80��6G   $��5q�6R   ��6%   �� *SearchCommand+6R   �� 5      $��Сохранить��6   $��80��6I   $��5q�6T   ��6)   �� *SaveCommand+6T   5       &   System.Windows.Controls.DataGrid  5"   
   -   5          Name$ clientsGrid��5"      $��1��6(      AutoGenerateColumns$ False��5$         CanUserAddRows$ False��5%      ��5#      �� *	Clients+   Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Фамилия��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *
LastName+6S     5(      $	 Имя��6%   $
 * 6P    62   �� *	FirstName+6P     5)      $	 Телефон��6%   $	
 120 6P    66   �� *Phone+6P     5*      $	 Email��6%   $	
 200 6N    64   �� *Email+6N   5,      �� 5.   
   $��2��6   .@�5/      �� ��6   �� *Clients.Count+ �� StringFormat$&  Всего клиентов: {0}��50      51      52      