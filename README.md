# Doodle Jump(2D)

> Doodle Jump is a 2009 platformer video game developed and published by Igor and Marko Pusenjak, who make up the Croatian studio Lima Sky. The game was released for Windows Phone, iOS, BlackBerry, Android, Java Mobile (J2ME), Nokia Symbian, and Xbox 360 for the Kinect.[2] It was released worldwide for iOS on April 6, 2009, Android and Blackberry on March 2, 2010, Symbian on May 1, 2010, Windows Phone 7 on June 1, 2011,[3] the iPad on September 1, 2011, and Windows Phone 8 on August 21, 2013.[4][5] Since its release, the game has been generally well received.

- **Difficulty**: Intermediate
- [**Download**](https://github.com/digiman07/DoodleJump/archive/refs/heads/main.zip)

**Menu Screen**
![alt text](https://raw.githubusercontent.com/digiman07/DoodleJump/main/Assets/Images/DoodleJump%20Menu.png)

**Game Screen**
![alt text](https://raw.githubusercontent.com/digiman07/DoodleJump/main/Assets/Images/DoodleJumpMain.png)

<div align='center'>
<h4> <a href=https://digiman07.github.io/DoodleJump/WebGL/>View Demo</a>
</div>


<div class="About" id="About"><b>Doodle Jump</b> is currently under development, but please feel free to give it a try.</br>We would also appreciate any suggestions on how we can improve on the game by posting your comments to our <a href="https://discord.com/channels/567442896815521793/568122387703398400">Discord server.</a></div>
<div id="unity-container" class="unity-desktop">
<canvas id="unity-canvas" width=960 height=600></canvas>
      <div id="unity-loading-bar">
        <div id="unity-logo"></div>
        <div id="unity-progress-bar-empty">
          <div id="unity-progress-bar-full"></div>
        </div>
      </div>
      <div id="unity-warning"> </div>
      <div id="unity-footer">
        <div id="unity-webgl-logo"></div>
        <div id="unity-fullscreen-button"></div>
        <div id="unity-build-title">Click for fullscreen</div>
      </div>
    </div>
    <script>
      var container = document.querySelector("#unity-container");
      var canvas = document.querySelector("#unity-canvas");
      var loadingBar = document.querySelector("#unity-loading-bar");
      var progressBarFull = document.querySelector("#unity-progress-bar-full");
      var fullscreenButton = document.querySelector("#unity-fullscreen-button");
      var warningBanner = document.querySelector("#unity-warning");

      // Shows a temporary message banner/ribbon for a few seconds, or
      // a permanent error message on top of the canvas if type=='error'.
      // If type=='warning', a yellow highlight color is used.
      // Modify or remove this function to customize the visually presented
      // way that non-critical warnings and error messages are presented to the
      // user.
      function unityShowBanner(msg, type) {
        function updateBannerVisibility() {
          warningBanner.style.display = warningBanner.children.length ? 'block' : 'none';
        }
        var div = document.createElement('div');
        div.innerHTML = msg;
        warningBanner.appendChild(div);
        if (type == 'error') div.style = 'background: red; padding: 10px;';
        else {
          if (type == 'warning') div.style = 'background: yellow; padding: 10px;';
          setTimeout(function() {
            warningBanner.removeChild(div);
            updateBannerVisibility();
          }, 5000);
        }
        updateBannerVisibility();
      }

      var buildUrl = "Build";
      var loaderUrl = buildUrl + "/Web.loader.js";
      var config = {
        dataUrl: buildUrl + "/Web.data.unityweb",
        frameworkUrl: buildUrl + "/Web.framework.js.unityweb",
        codeUrl: buildUrl + "/Web.wasm.unityweb",
        streamingAssetsUrl: "StreamingAssets",
        companyName: "M.H Software",
        productName: "Doodle Jump",
        productVersion: "1.0",
        showBanner: unityShowBanner,
      };

      // By default Unity keeps WebGL canvas render target size matched with
      // the DOM size of the canvas element (scaled by window.devicePixelRatio)
      // Set this to false if you want to decouple this synchronization from
      // happening inside the engine, and you would instead like to size up
      // the canvas DOM size and WebGL render target sizes yourself.
      // config.matchWebGLToCanvasSize = false;

      if (/iPhone|iPad|iPod|Android/i.test(navigator.userAgent)) {
        container.className = "unity-mobile";
        // Avoid draining fillrate performance on mobile devices,
        // and default/override low DPI mode on mobile browsers.
        config.devicePixelRatio = 1;
        unityShowBanner('WebGL builds are not supported on mobile devices.');
      } else {
        canvas.style.width = "960px";
        canvas.style.height = "600px";
      }
      loadingBar.style.display = "block";

      var script = document.createElement("script");
      script.src = loaderUrl;
      script.onload = () => {
        createUnityInstance(canvas, config, (progress) => {
          progressBarFull.style.width = 100 * progress + "%";
        }).then((unityInstance) => {
          loadingBar.style.display = "none";
          fullscreenButton.onclick = () => {
            unityInstance.SetFullscreen(1);
          };
        }).catch((message) => {
          alert(message);
        });
      };
      document.body.appendChild(script);
    </script>
