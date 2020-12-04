Vue.component("blockMaliciousPatients", {
	data: function () {
		return {
		
		}
	},
	template: `
	<div>
	
	<div class="boundary-for-scroll-block-malicious-patients">
	     <div class="logoAndName">
	         <div class="logo">        
	             <img src="images/hospital.png"/>
	         </div>
	         <div class="webName">
	             <h3></h3>
	         </div>  
	     </div>
	 
	     <div class="main">     
	         <ul class="menu-contents">
				<li><a href="#/">Pretraga dokumenata</a></li>
				<li class="active"><a href="#/">Anketa</a></li>
	         </ul>
	     </div>
 
	     <div class="dropdown">
	        <button class="dropbtn">
	        	<img id="menuIcon" src="images/menuIcon.png" />
	        	<img id="userIcon" src="images/user.png" />
	        </button>
		    <div class="dropdown-content">
		        <a >Registruj se</a>
	            <a >Prijavi se</a>
		    </div>
		</div>
		
	<div class="malicious-patients-vertical-line"></div>
	
	 <div class="sideComponents">      
	     <ul class="ulForSideComponents">
			
	     </ul>
	 </div>

	
	<div class="block-malicious-patients">	
		<h3 class = "block-malicious-patients-title">Spisak potencijalno zlonamernih korisnika:</h3> 
		<table class="table-block-malicious-patients">
			<tr>
				<th>Korisničko ime</th>
                <th>Ime</th>
                <th>Prezime</th>
                <th style="max-width:90px;">Broj otkazivanja na mesečnom nivou</th>
                <th></th>
			</tr>
			<tr>
                <td>mare</td>
                <td>Marko</td>
                <td>Markovic</td>
                <td>7</td>
                <td>
                <button style="width: 130px; height: 40px; font-size: 16px;" type="button" @click="blockUser()">Blokiraj</button>
                </td>
            </tr>
            <tr>
                <td>mare</td>
                <td>Marko</td>
                <td>Markovic</td>
                <td>7</td>
                <td>
                <button style="width: 130px; height: 40px; font-size: 16px;" type="button" @click="blockUser()">Blokiraj</button>
                </td>
            </tr>
            <tr>
                <td>mare</td>
                <td>Marko</td>
                <td>Markovic</td>
                <td>7</td>
                <td>
                <button style="width: 130px; height: 40px; font-size: 16px;" type="button" @click="blockUser()">Blokiraj</button>
                </td>
			</tr>
			
		</table> 
	</div>
	     
	</div>	  
	</div>
        
	`
	,
	methods: {
		blockUser : function() {
            if (confirm('Da li ste sigurni da želite da izvršite izmenu naloga?') == true) {
                toast('Izmena je uspešno izvršena!')
            }else{
                toast('Izmena nije izvršena!')
            }

        }

	},
	computed: {

	},
	mounted() {

	}

});