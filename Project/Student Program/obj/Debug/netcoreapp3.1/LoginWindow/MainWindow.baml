   M S B A M L   `   `   `  ����J  FStudent Program, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:Student_Program.LoginWindowStudent_Program.LoginWindow  5   	   ,    &Student_Program.LoginWindow.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   5local)clr-namespace:Student_Program.LoginWindow  5   	   -   5          � WindowStyle$
  None=�5	   	    � 
ResizeMode$ CanMinimize=�5
   	   (  "MahApps.Metro.Controls.MetroWindow   IgnoreTaskbarOnMaximize$
 True��5   	      WindowTitleBrush
 �   � � WindowStartupLocation$ CenterScreen=�5   	      WindowTransitionsEnabled$ False��5   	   
���   � � Title$ 
MainWindow��5   	   $	��550��6   $	��650��6)      	GlowBrush
 ��� �.��5      � ���	#FF12063A.+�5   
   �  � RowDefinitions 5      �� 5      $��0.18* �6    61   �� 5      6"   �� 5      6"   .+�5      �� $��Right=�6   	 �� Orientation$	 
Horizontal=�65   $��0,0,35,0q�6N   .+�5      �� -   5        $��5q�5      
���   �$��2q�68   ���	#FFD6F3EF$��45��6c   .��6�   
Войти6�   �� 5      -   5        $	��0,5q�5      
���   �$��2q�6:   ���	#FFD6F3EF$	��125��6e   .��6�   &$Зарегистрироваться6�   5      5       � 5   
   -   5        $��frame��5      $��35q�6   ���	#FFD6F3EF
���   �$��2q�6T   
  � NavigationUIVisibility$
 Hidden=�6h   6�   5      5       