   M S B A M L   `   `   `  ����B  >CheerUp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:CheerUpCheerUp  5   	       CheerUp.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:CheerUp     5   	     � Title$  CheerUp��5   	   $	��600��6   $	��350��6&    � WindowStyle$
 None=�62    � AllowsTransparency . 
������ .��5	      � .+�5
   
   ��  �� CornerRadius$ 5��6   ���#673ab7._�5      � 
������ .+�5      � $
��Left=�6   $	��449��62   $��	0,136,0,0q�6?   $	��Top=�6R   $	��350��6j   ���#212121.+�5      �� -   5         ��Name$ 
id_textbox��5      $
��Left=�6F   $��28��6a   $��
26,221,0,0q�6m    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��300��6�   $��Center=�6�   
����������	#FF424242$��NanumGothic)�6  ��62   �� *Id+��6�   Z� 6  G� 5      -   5         G�Name$ password_textbox��5   "   $
��Left=�6o   $��28��6�   $��
26,291,0,0q�6�   $	��Top=�6�   $	��300��6�   $��Center=�6�   
����������	#FF424242$��NanumGothic)�61  ��6�   Z� 61  �� 5      -   5         ��Name$ AutoLogin_Checkbox��5      $��자동 로그인��6;   $
��Left=�6L   $��
26,392,0,0q�6g   $	��Top=�6{   $��NanumGothic)�6�   ���	#FF646464
�������$��Center=�6�   5      �� 5      -   5         ��Name$ header��5      $
��Left=�6(   $	��220��6C   $	��Top=�6P   $	��350��6h   $��0,10,0,0q�6t   $��../Image/Header.png��6�   �� 5      -   5        	 ��Name$	 header_label��5      $��Account��6.   $
��Left=�6@   $��	10,14,0,0q�6[   $	��Top=�6n   $��14(�6�   
�������$��NanumGothic Light)�6�   �� 5      -   5        $ account_btn��5      $
��Left=�6-   $��41��6H   $��	15,90,0,0q�6T   $	��Top=�6g   $��41��6   $*��$/CheerUp;component/Image/account.png��6�   �� 5      -   5        $	 header_label_Copy��5      $#��로그인이 필요합니다!��63   $
��Left=�6I   $��	69,86,0,0q�6d   $	��Top=�6w   $��18(�6�   
�������$��NanumSquareRound Bold)�6�   �� 5      -   5        $	 header_label_Copy1��5      $ ��계정이 없으신가요?��64   $
��Left=�6I   $��
69,116,0,0q�6d   $	��Top=�6x   
�������$��NanumSquareRound Bold)�6�   �� 5      -	   5        $	 header_label_Copy2��5      $��회원가입��64   $
��Left=�6C   $��173,116,0,0q�6^   $	��Top=�6s   ���	#FF1A237E$��NanumSquareRound Bold)�6�   
 � Cursor$

 Hand��6�   �� 5      -
   5        $	 header_label_Copy3��5      $��LOGIN��64   $
��Left=�6D   $��
20,281,0,0q�6_   $	��Top=�6s   
�������$��NanumSquareRound Bold)�6�   $��18(�6�   �� 5      -   5        $	 header_label_Copy4��5      $��	로그인��64   $
��Left=�6B   $��
79,281,0,0q�6]   $	��Top=�6q   ���	#FF919191$��NanumSquareRound Bold)�6�   $��18(�6�   �� 5      -   5        $	 header_label_Copy5��5      $��ID��64   $
��Left=�6A   $��
29,325,0,0q�6\   $	��Top=�6p   ���	#FF919191$��NanumSquareRound Bold)�6�   �� 5      -   5        $	 header_label_Copy6��5      $��PW��64   $
��Left=�6A   $��
29,395,0,0q�6\   $	��Top=�6p   ���	#FF919191$��NanumSquareRound Bold)�6�   5      5      �� 5   
   -   5         ��Name$ button��5      $��	로그인��6!   $
��Left=�6/   $��
27,484,0,0q�6J   $	��Top=�6^   $	��299��6v   ���	#FF424242���	#FFEEEEEE$��30��6�   $��NanumGothic)�6�   $

 Hand��6�   ��6�   Z� 6�   5      5      