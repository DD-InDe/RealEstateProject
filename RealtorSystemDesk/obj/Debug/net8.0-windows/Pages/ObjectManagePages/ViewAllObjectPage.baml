   M S B A M L   `   `   `  ����L  HRealtorSystemDesk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:RealtorSystemDesk.PagesRealtorSystemDesk.Pages  5      /    )RealtorSystemDesk.Pages.ViewAllObjectPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a>design1http://materialdesigninxaml.net/winfx/xaml/themes  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      1local%clr-namespace:RealtorSystemDesk.Pages  5      -   5          N� Title$  Объекты��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   #  MaterialDesignThemes.Wpf.Card  $��5q�6   $��5q�5      .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      ��  %  !MaterialDesignBodyMediumTextBlock#���   6   $��Center=�5      $��
Поиск��5      �� 5      -   5         ��Name$ SearchTextBox��5      $	��200��5      $��7q�5      5      �� 5      #���   6   $��Center=�5      $��Тип объекта��5      �� 5       -   5         ��Name$ TypeComboBox��5       $	��200��5!      $��7q�5"       �� DisplayMemberPath$
 Name��5#      5$      5%      5&        5(   
   $��5q�6   $��1��5)      $��5q�5*      .��5+      &   System.Windows.Controls.DataGrid  -   5          Name$ ObjectDataGrid��5+         
IsReadOnly$
 True��5,         AutoGenerateColumns$ False��5-      	   Columns	 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn
   Header$
 
Адрес��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 50   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 51   )   �� *	Address+  52      $
 Кол-во комнат��6)   $ * 53   )    54   )   �� *
RoomsCount+  55      $
 Тип объекта��6)   $ * 56   )    57   )   �� *	Type.Name+  58      $
 Клиент��6)   $ * 59   )    5:   )   �� *Contract.Client.FullName+4  .System.Windows.Controls.DataGridTemplateColumn  5;      $
 0.5* 6-      CellTemplate 5<      �� 5=      .R�5>   "   ��  ��Name$ 
InfoButton��5@   )   -   5        $��Инфо��5>   )     MaterialDesignFlatButton#���  5?   )   5A   )   5B      5D      5F      5G      5H      5I      