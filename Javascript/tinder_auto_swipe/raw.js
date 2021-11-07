const like_btn = document.evaluate('//*[@id="q-274726726"]/div/div[1]/div/main/div[1]/div/div/div[1]/div/div/div[4]/div/div[4]/button', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
try {
	setInterval(() => {
		like_btn.click();
	}, 10000);
	
} catch (error) {
	console.log(error);
}
