function closeopen(elem,elem2){
	el1 = document.getElementsByName(elem);
	el = el1[1];
	if (el.className == 'opened') { el.className = 'closed'; elem2.innerHTML = '►'; }
	else if (el.className == 'closed') { el.className = 'opened'; elem2.innerHTML = '▼'; }
}

var before_id = 0;
function info(element){
	el = document.getElementById(element);
	el.className = 'visible';
	closewind(before_id, element);
}

function closewind(wind, elem1) {
    try {el = document.getElementById(wind);
        el.className = 'invisible';}
    catch(err) {}
	before_id = elem1;
}
