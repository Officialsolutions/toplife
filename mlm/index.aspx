<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Toplife | Homepage</title>

<style>
.text-box
{
border:4px solid #c74090;
}
.text-box1
{
border:4px solid #fba714;
}
.client-btn
{
background:#37f329;
}
</style>
<link rel="stylesheet" href="css/reset.css" type="text/css" />

<link rel="stylesheet" href="css/styles.css" type="text/css" />
<script type="text/javascript" src="js/jquery.js"></script>
<script type="text/javascript" src="js/sticky.min.js"></script>
<script type="text/javascript" src="js/custom.js"></script>
<script type="text/javascript" src="js/bootstrap.js"></script>
<script type="text/javascript" src="js/bootstrap.min.js"></script>
<script type="text/javascript" src="js/npm.js"></script>

<meta name="viewport" content="width=device-width, minimum-scale=1.0, maximum-scale=1.0" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<header>
			<div class="width">
				<div class=>
				<a href="index.html"><img src="img/logo.png" class="img"></a

			></div>
				
		</header>

		<nav id="mainnav">
			<div class="width">
  				<ul>
                            	<li class="selected-item"><a href="index.aspx">Home</a></li>
                           		<li><a href="about.html">About Us</a></li>
                           		<li><a href="product.html">Products</a></li>
								<li><a href="plan.html">Business plan</a></li>
								<li><a href="gallery.html">Gallery</a></li>	
                      <li><a href="Achievers.aspx">Achiever</a></li>								
                            	<li><a href="contact.html">Contact</a></li>
                            	<li><a href="client.aspx">Login</a></li>
                            	<li><a href="reg.aspx?pin=">Register</a></li>
                            	<li><a href="toplife.pdf">KYC</a></li>
                        	</ul>

				<div class="clear"></div>
		
			</div>
		</nav>

		



		<section id="body">
			<aside id="sidebar" class="column-left">

			
			<div id="sticky">
			

			<div class="responsive-sidebar-hide block">
				<p class="text-block">
					<img src="img/logo1.jpg">
				</p>
               		 </div>

                    	<div class="responsive-sidebar-hide block">
				<div class="bg-1">
					<h4 style="color:#fba919;">APPLICATION FORMS FOR</h4>
					<ul>
					<li class="li-bg"><a href="#">Direct Seller</a></li>
					<li class="li-bg"><a href="#">Mobile No. Change</a></li>
					<li class="li-bg"><a href="#">Revival of Non Renwed ID</a></li>
					</ul>
				</div>
				</div>
				<br>
				
				
			
			

			<div class="responsive-buttons">
				<a href="#sidebar" id="show-sidebar-button">Show sidebar</a>
			</div>

			
			</div>
			</aside>
			<section id="content" class="column-right"> 		
	    <article>
			<h2>Introduction to TopLife</h2>
			
			<!---  ===========================================================================
			
												Slider
			=====================================================================================-->
			
			 <script src="js/jssor.slider-21.1.6.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        jssor_1_slider_init = function () {

            var jssor_1_SlideoTransitions = [
              [{ b: 0, d: 600, y: -290, e: { y: 27}}],
              [{ b: 0, d: 1000, y: 185 }, { b: 1000, d: 500, o: -1 }, { b: 1500, d: 500, o: 1 }, { b: 2000, d: 1500, r: 360 }, { b: 3500, d: 1000, rX: 30 }, { b: 4500, d: 500, rX: -30 }, { b: 5000, d: 1000, rY: 30 }, { b: 6000, d: 500, rY: -30 }, { b: 6500, d: 500, sX: 1 }, { b: 7000, d: 500, sX: -1 }, { b: 7500, d: 500, sY: 1 }, { b: 8000, d: 500, sY: -1 }, { b: 8500, d: 500, kX: 30 }, { b: 9000, d: 500, kX: -30 }, { b: 9500, d: 500, kY: 30 }, { b: 10000, d: 500, kY: -30 }, { b: 10500, d: 500, c: { x: 87.50, t: -87.50} }, { b: 11000, d: 500, c: { x: -87.50, t: 87.50}}],
              [{ b: 0, d: 600, x: 410, e: { x: 27}}],
              [{ b: -1, d: 1, o: -1 }, { b: 0, d: 600, o: 1, e: { o: 5}}],
              [{ b: -1, d: 1, c: { x: 175.0, t: -175.0} }, { b: 0, d: 800, c: { x: -175.0, t: 175.0 }, e: { c: { x: 7, t: 7}}}],
              [{ b: -1, d: 1, o: -1 }, { b: 0, d: 600, x: -570, o: 1, e: { x: 6}}],
              [{ b: -1, d: 1, o: -1, r: -180 }, { b: 0, d: 800, o: 1, r: 180, e: { r: 7}}],
              [{ b: 0, d: 1000, y: 80, e: { y: 24} }, { b: 1000, d: 1100, x: 570, y: 170, o: -1, r: 30, sX: 9, sY: 9, e: { x: 2, y: 6, r: 1, sX: 5, sY: 5}}],
              [{ b: 2000, d: 600, rY: 30}],
              [{ b: 0, d: 500, x: -105 }, { b: 500, d: 500, x: 230 }, { b: 1000, d: 500, y: -120 }, { b: 1500, d: 500, x: -70, y: 120 }, { b: 2600, d: 500, y: -80 }, { b: 3100, d: 900, y: 160, e: { y: 24}}],
              [{ b: 0, d: 1000, o: -0.4, rX: 2, rY: 1 }, { b: 1000, d: 1000, rY: 1 }, { b: 2000, d: 1000, rX: -1 }, { b: 3000, d: 1000, rY: -1 }, { b: 4000, d: 1000, o: 0.4, rX: -1, rY: -1}]
            ];

            var jssor_1_options = {
                $AutoPlay: true,
                $Idle: 2000,
                $CaptionSliderOptions: {
                    $Class: $JssorCaptionSlideo$,
                    $Transitions: jssor_1_SlideoTransitions,
                    $Breaks: [
                  [{ d: 2000, b: 1000}]
                ]
                },
                $ArrowNavigatorOptions: {
                    $Class: $JssorArrowNavigator$
                },
                $BulletNavigatorOptions: {
                    $Class: $JssorBulletNavigator$
                }
            };

            var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);

            /*responsive code begin*/
            /*you can remove responsive code if you don't want the slider scales while window resizing*/
            function ScaleSlider() {
                var refSize = jssor_1_slider.$Elmt.parentNode.clientWidth;
                if (refSize) {
                    refSize = Math.min(refSize, 600);
                    jssor_1_slider.$ScaleWidth(refSize);
                }
                else {
                    window.setTimeout(ScaleSlider, 30);
                }
            }
            ScaleSlider();
            $Jssor$.$AddEvent(window, "load", ScaleSlider);
            $Jssor$.$AddEvent(window, "resize", ScaleSlider);
            $Jssor$.$AddEvent(window, "orientationchange", ScaleSlider);
            /*responsive code end*/
        };
        
    </script>
   
    <div id="jssor_1" style="position: relative; margin: 0 auto; top: 0px; left: 0px; width: 600px; height: 300px; overflow: hidden; visibility: hidden;">
        <!-- Loading Screen -->
        <div data-u="loading" style="position: absolute; top: 0px; left: 0px;">
            <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; top: 0px; left: 0px; width: 100%; height: 100%;"></div>
            <div style="position:absolute;display:block;background:url('img/loading.gif') no-repeat center center;top:0px;left:0px;width:100%;height:100%;"></div>
        </div>
        <div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 600px; height: 300px; overflow: hidden;">
            <asp:ListView ID="lvslider" runat="server">
                <ItemTemplate>
                     <div data-p="112.50" style="display: none;">
                <img data-u="image" src="../uploadimage/<%#Eval("image") %>" />
                
            </div>
                </ItemTemplate>
            </asp:ListView>
           
            
        </div>
        <!-- Bullet Navigator -->
        <div data-u="navigator" class="jssorb01" style="bottom:16px;right:16px;">
            <div data-u="prototype" style="width:12px;height:12px;"></div>
        </div>
        <!-- Arrow Navigator -->
        <span data-u="arrowleft" class="jssora02l" style="top:0px;left:8px;width:55px;height:55px;" data-autocenter="2"></span>
        <span data-u="arrowright" class="jssora02r" style="top:0px;right:8px;width:55px;height:55px;" data-autocenter="2"></span>
    </div>
    <script type="text/javascript">        jssor_1_slider_init();</script>
			
			
			<!---  ===========================================================================
			
												end Slider
			=====================================================================================-->
			
			
			
		</article>				
		</section>

		<div class="clear"></div>

	</section>
	<section>
		
	</section>
	

    <footer>
        <div class="footer-content width">
            <ul>
            	<li><h4>Hot Link</h4></li>
                <li><a href="#">Login</a></li>
                <li><a href="#">Sign Up</a></li>
                <li><a href="#">About Us</a></li>
                <li><a href="#">Privacy Policy</a></li>
                <li><a href="#">Contact Us</a></li>
            </ul>
            
            <ul>
            	<li><h4>Popular Page</h4></li>
                <li><a href="#">Home</a></li>
                <li><a href="#">Gallery </a></li>
                <li><a href="#">Business Plan</a></li>
                
            </ul>

 	    <ul>
                <li><h4>About Us</h4></li>
                <li><a href="#">Morbi hendrerit libero </a></li>
                <li><a href="#">Proin placerat accumsan</a></li>
                <li><a href="#">Rutrum nulla a ultrices</a></li>
                <li><a href="#">Curabitur sit amet tellus</a></li>
                <li><a href="#">Donec in ligula nisl.</a></li>
            </ul>
            
            <ul class="endfooter">
            	<li><h4>Address:-</h4></li>
                <li><address>
		<STRONG>TOPLIFE HOME PRODUCTS PVT.LTD</STRONG></br>
		Gill Chowk, Near City Park, Moga-142001(Pb.)<br>
		Mobile: 01636-225226<br>
		</address></li>
            </ul>
            
            <div class="clear"></div>
        </div>
        <div class="footer-bottom">
            <p>&copy; Toplife 2016.</p>
         </div>
    </footer>
    </div>
    </form>
</body>
</html>
