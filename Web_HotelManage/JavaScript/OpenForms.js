 function HhowForms(url,width,height)
  {
//    window.showModalDialog(url, 'obj', 'dialogWidth='+width+'px;dialogHeight='+height+'px');
//  
//    window.location.reload(); 

        var answer=window.showModalDialog(url, 'obj', 'dialogWidth='+width+'px;dialogHeight='+height+'px'); 
        if(answer==1){ 
        //window.location.href = "demand.do?method=selmd&d="+escape(new Date()); //转到处理页面 
        window.location.reload(); //刷新父窗口 
        //winow.location.reload(true); 

        } 
  }
  
  
  
  function PopWindow(url,width,height)
  {
    var result=showModalDialog(url,'obj','dialogWidth:'+width+'px;dialogHeight:'+height+'px;center:yes;help:no;resizable:no;status:no;');
  location.href=location.href;
  }
