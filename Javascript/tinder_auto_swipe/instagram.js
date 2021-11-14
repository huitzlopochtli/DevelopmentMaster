const upper_left = document.evaluate('/html/body/div[1]/section/main/div/div[3]/article/div[1]/div/div[1]/div[1]/a/div[1]/div[2]', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;

upper_left.click();

let first_click = false;

let likeNNext = () => {

	var min = 5,
		max = 6;
	var rand = Math.floor(Math.random() * (max - min + 1) + min);

	setTimeout(() => {
		let like_btn = document.evaluate('/html/body/div[6]/div[2]/div/article/div/div[2]/div/div/div[2]/section[1]/span[1]/button', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
		let is_not_liked = Array.from(like_btn.lastElementChild.classList).includes('rrUvL') ;
	
	
		if(!is_not_liked){
			like_btn.click();
		}
	}, 1000);

	setTimeout(() => {
		if(!first_click){
			let right_btn = document.evaluate('/html/body/div[6]/div[1]/div/div/div/button', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
			first_click = true;
			right_btn.click();	
		} else{
			let right_btn = document.evaluate('/html/body/div[6]/div[1]/div/div/div[2]/button', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
			right_btn.click();	
		}
	}, 2000);

	setTimeout(likeNNext, rand * 1000);
};

likeNNext();




