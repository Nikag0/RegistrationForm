   M S B A M L   `   `   `  ����C  ?UsersApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:UsersAppUsersApp  5   	   "    UsersApp.AuthorizationWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:UsersApp     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        � Title$  AuthorizationWindow��5	   	   $	��450��6%   $	��800��62    � DataContext 5
         UsersApp.ViewModel  5   
   .��5      � .+�5   
   �� $	��400��6   $��5,0,7,0q�6    
�������$��Center=�6D    �� Padding$ 30q�6_   $	��550��6l    �� CornerRadius$ 20��6{    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6#      Color$ 	LightGray��63      ShadowDepth$ 5Q�6E   ._�5       �� .+�5"      �� $��Stop Authorization��6=   $
��Left=�6Z    d� 	IsChecked 6   �� *InputAccess+��6u   �� *EnabledText+��5#      �� 5$      	 �� 
TargetType"	 ��6    5&      �� 5(      $��Right=�6W   ��6   �� *Timer+��63   �� *TimetButtonText+6W   �� 5)      $��Right=�66   $��80��6R   ��6   �� *
TimerNum+6R   �� 5*      $
��0 10q�6   $��Center=�6*   $��Authorization��6G   $��20(�6\   $
��Bold"�6j   �� 5+      $��Center=�6S   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Login��6p   ��6   �� *Login+{�61   �� *InputAccess+6p   �� 5,      $��Center=�6V   $
 Password��6s   ��6   �� *
Password+{�64   �� *InputAccess+6s   � 5.      .+�5/      �� -   5        $��ButtonCreateAccount��5/      $
��Left=�6e   $��Create account��6�      MaterialDesignFlatButton#��[  6�   ��68   �� *ButtonCreateAccountClick+6�   �� 50      -   5        $��ButtonSignIn��50      $��Right=�6W   $��Sign in��6s   #��[  6�   ��61   �� *ButtonSignInClick+6�   51      52      53      54      55      