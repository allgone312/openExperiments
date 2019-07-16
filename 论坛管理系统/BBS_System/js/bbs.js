// JavaScript Document
function initBlock(num){
	var i,
	    str="";
	for(i=1;i<=num;i++){
		var aBlock="<p class='weui-grid__label'>"+"版块"+i+"</p>";
		aBlock="<div class='weui-grid__icon'><img src='img/icon_tabbar.png' alt=''></div>"+aBlock;
		aBlock="<a href='posting.html' class='weui-grid'>"+aBlock+"</a>";
		str+=aBlock;
	}
	return str;
}
function initGrids(obj,num){
	var items=document.getElementsByClassName("weui-navbar__item");
	var i;
	for(i=0;i<items.length;i++){
		if(items[i].classList.contains("weui-bar__item_on")){
			items[i].classList.remove("weui-bar__item_on")
		}
	}
	obj.classList.add("weui-bar__item_on");
	
	var str=initBlock(num);
	document.getElementById("allBlock").innerHTML=str;
}
function toPostingContent(){
	window.location.href="postingContent.html";
}
function postMessage(){
	window.location.href="postMessage.html";
}