   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfApp2.ViewModelsWpfApp2.ViewModels  5      /clr-namespace:WpfApp2.ModelsWpfApp2.Models  5      !    WpfApp2.Views.WarehouseView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /vm clr-namespace:WpfApp2.ViewModels     5      /modelsclr-namespace:WpfApp2.Models     5        � DataContext  5      +   %WpfApp2.ViewModels.WarehouseViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��5q�6;   .+�5      �� $	��200��6   $��5q�5      ��5      �� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5      $��
Поиск��6   $��80��5      $��5q�5      ��5      �� *SearchCommand+5      �� 5      $!��Новая поставка��6   $	��120��5!      $��5q�5"      ��5       �� *NewSupplyCommand+5"      5#      &   System.Windows.Controls.DataGrid  5%   
   -   5        $��1��5%         AutoGenerateColumns$ False��5'         CanUserAddRows$ False��5(      ��5&      �� *
Products+   Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5.   $   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5-   $   �� *Name+5.   $     5/      $ Количество��6%   $	 100 51   $   	 50   $   �� *
Quantity+51   $     52      $ Поставщик��6%   $	 150 54   $   	 53   $   �� *
Supplier+54   $     55      $ Дата��6%   $	 120 57   $   	 56   $   �� *Date+
 �� StringFormat$
 
dd.MM.yyyy��57   $   59      �� 5;   
   $��2��6   .@�5<      �� ��6   �� *Products.Count+$$
 Всего позиций: {0}��5=      5>      5?      