   M S B A M L   `   `   `  ����V  RARM_Of_Phone_seller_PROJECT, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ARM_Of_Phone_seller_PROJECTARM_Of_Phone_seller_PROJECT  5      &     ARM_Of_Phone_seller_PROJECT.Auth   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:ARM_Of_Phone_seller_PROJECT     5        N� Title$
  Auth��5	      $��974.4��6   $	��480��6"   .��5      � $��974.4��6   $	��480��6    +� FocusedElement 6&   ��  �� ElementName$ 
Auth_Login�� � RowDefinitions 5   
   �� 5       � ColumnDefinitions 5   
   �� 5      .+�5   
   �� $ ��Введите логин:��6   $
��Left=�6)   $��427,95,0,354q�6D   $��98��6Z   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6e   
�������6�   �� 5   
   $"��Введите пароль:��6   $
��Left=�6*   $��427,154,0,0q�6E   $	��Top=�6Z   $	��112��6r   $��26��6~   $ Display=�6�   
�������6�   �� 5   
   -   5         ��Name$ 
Auth_Login��5      $
��Left=�6&   $��23��6A   $��382,126,0,0q�6M    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��200��6�   $ Display=�6�   G� 5   
   -   5         G�Name$ Auth_Password��5      $
��Left=�6-   $��381,185,0,0q�6H   $	��Top=�6]   $	��200��6u   $��23��6�   $ Display=�6�   6�   �� 5   
   -   5        	 ��Name$	 Auth_Button_Login��5      $&�� Авторизироваться��6,   $
��Left=�6m   $��381,213,0,0q�6�   $	��Top=�6�   $	��200��6�   $��30��6�   $ Display=�6�   
   TextHintingMode$
 Fixed=�6�   ��6G   �� *SelectСпециалисты+6  �� 5   
   -   5        $	 Auth_Button_Guest��5      $"��Войти как гость��6,   $
��Left=�6F   $��381,248,0,0q�6a   $	��Top=�6v   $	��200��6�   $��30��6�   $ Display=�6�   $
 Fixed=�6�   ���	#FFFF98986  �� 5   
   -   5        $
��Left=�5      $��819,420,0,0q�6,   $	��Top=�6A   $	��145��6Y   $��50��6e   .��5      ��  �� Orientation$ 
Horizontal=�6   $��40��62   .+�5      �� $)��#pack://application:,,,/Icons/DB.png��6   $��36��6E   �� 5      $	��101��6    �� TextAlignment$ Center=�6(   �� 6@   $�Изменить ��6D   �� 6W   �� 6c   $#�привязку данных��6g   6�   5      5      �� 5   
   -   5         ��Name$ 	HintBlock��5      $��287.2,283,287.2,107q�6'   $
��Wrap=�6D   $�� ��6X   
���  ��6`   5       5!      