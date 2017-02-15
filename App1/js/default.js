

	        var webview = document.getElementById('webview');

	        webview.style.height = '100%';
	        webview.style.width = '100%';

	        var communicationWinRT = new CommunicationWinRT.CommunicationWinRT();
	        var cameraWinRT = new CommunicationWinRT.cameraWinRT();
	        webview.addWebAllowedObject("jeffRocks", communicationWinRT);
	       // webview.addWebAllowedObject("jeffRocksCamera", cameraWinRT);
	        webview.navigate("ms-appx-web:///page.html");
	       // webview.navigate("https://testjeff.azurewebsites.net");

