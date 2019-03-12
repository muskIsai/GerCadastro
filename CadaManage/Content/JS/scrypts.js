/*Практика JavaScript*/
function SetIMG(selected_url)
{
   var item = document.getElementById("Preview");
    item.src=selected_url;
}
/*Практика jQuery*/
$(document).ready(function(){
   $('#header').fadeTo(2000,0.3,function(){ 
       $('html, body').animate({ scrollTop: $('#content').offset().top }, 2000);
   });
});

/*Ajax jQuery*/
$(document).on('submit','form',function(){
    
    var UserName=$('input[name=Name]').val();
    var UserTel=$('input[name=Tel]').val();
    var Car=$('select').val();
    //Валидация введенных данных.
    //Проверяем имя
    if(UserName.length>0)
    {
    //Проверяем номер телефона
    var regular=/^\8-[0-9]{3}-[0-9]{3}-[0-9]{4}/;
    if(regular.test(UserTel)==true)
    {
        alert('Всё норм!');
     SubmitForm(UserName,UserTel,Car);
    }
    else
    {
        alert("Вы неверно указали номер телефона");
    }
    }
    else{
        alert("Вы забыли указать имя");
    }
});

/*Ajax jQuery*/
function SubmitForm(name,tel,car)
{
   $.ajax({
  method: "POST",
  url: "/Home/Index",
  data: { Name: name, Tel: tel, Car:car }
})
  .done(function( msg ) {
    alert( "Отлично: " + msg );
  }).fail(function() {
    alert( "При передачи данных произошла ошибка" );
  }); 
}

