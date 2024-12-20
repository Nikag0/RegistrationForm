Добавил таймер в класс AuthorizationWindow. Такой класс не должен содержать бекенд. Наверное, мне стоило добавить таймер в класс UserManager.
Я попытался это сделать, но у меня не вышло передать из класса UserManager в класс AuthorizationWindow изменение поля timerNum метода Timer_Tick.

Добавил методы CheckBoxAuthorizationOn и CheckBoxAuthorizationOff в класс AuthorizationWindow. Помню, что вы просили масштабировать ситцацию. В случае, 
если таких TextBox будет много, такой способ не подойдёт. Думаю, что можно забиндить свойства IsEnabled к булевой переменной, которая бы меняла своё значение 
по переключению Checked и Unchecked.Но я не успел сделать это до выходных, поэтому оставил как есть, чтобы показать вам.

Добавил библиотеку UserManager с тремя классами: Usermanager, DataUser и DataUserRegOrAuth.
 