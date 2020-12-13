Vue.component("blockMaliciousPatients", {
	data: function () {
		return {
			maliciousPatients: []
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
				<li class="active"><a>Zlonamerni korisnici</a></li>
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
			<tr v-for = "maliciousPatient in maliciousPatients">
				<td>{{maliciousPatient.username}}</td>
				<td>{{maliciousPatient.name}}</td>
				<td>{{maliciousPatient.surname}}</td>
				<td>{{maliciousPatient.numberOfCancelledAppointents}}</td>
				<td v-if="maliciousPatient.blocked === false">
				<button style="width: 130px; height: 40px; font-size: 16px;" type="button" @click="blockUser(maliciousPatient.id)">Blokiraj</button>
				</td>
				<td v-if="maliciousPatient.blocked === true" style="color: red">
					Pacijent je blokiran
				</td>
			</tr>			
		</table> 
	</div>
	     
	</div>	  
	</div>
        
	`
	,
	methods: {
		blockUser : function(patientId) {
			if (confirm('Da li ste sigurni da želite da blokirate pacijenta?') == true) {
				axios.put('api/patient/blockMaliciousPatient/' + patientId)
					.then(response => {
						axios.get('api/patient/getMaliciousPatients').then(response => {
							this.maliciousPatients = response.data;
						});
					});
                toast('Uspešno ste blokirali pacijenta!')
            }
        }

	},
	computed: {

	},
	mounted() {
		axios.get('api/patient/getMaliciousPatients').then(response => {
			this.maliciousPatients = response.data;
		});
	}

});