Vue.component("eventSourcingStatistic", {
	data: function () {
		return {
			userToken: null,
			loggedUserId: 0
		}
	},
	template: `
	<div>
	
	<div class="boundaryForScrollSurvey">
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
				<li><a href="#/patientsFeedbacks" style="margin-left:-37%">Utisci pacijenata</a></li>
				<li><a href="#/surveyResults" style="margin-left:-44%">Rezultati anketa</a></li>
				<li class="active" style="margin-left:-12%"><a href="">Praćenje događaja</a></li>
				<li><a href="#/blockMaliciousPatients" style="margin-left:-6%">Zlonamerni korisnici</a></li>
	         </ul>
	     </div>
 
	     <div class="dropdown">
	        <button class="dropbtn">
	        	<img id="menuIcon" src="images/menuIcon.png" />
	        	<img id="userIcon" src="images/user.png" />
	        </button>
		    <div class="dropdown-content">
		        <a href="#/userLogin" @click="logOut()">Odjavi se</a>
		    </div>
		</div>
	
    <div class="event-sourcing-questions" style="margin-left:14.5%">
		<h3>Statistika praćenja događaja pri zakazivanju pregleda</h3>
		<table class="event-sourcing-statistic-table" style="margin-bottom : 40px">
			<tr>
				<th style="min-width:430px;">Statistički parametar</th>
				<th style="min-width:90px;">Vrednost</th>			
			</tr>
			<tr>
				<td>Prosečna uspešnost zakazivanja pregleda</td>
				<td>85%</td>
			</tr>
			<tr>
				<td>Prosečno vreme zakazivanja</td>
				<td>125.24s</td>
			</tr>
			
		</table> 

	</div>
	
	 
	 

	     
	</div>	  
	</div>
        
	`
	,
	methods: {
		logOut: function () {
			localStorage.removeItem("validToken");
		}
	},
	computed: {

	},
	mounted() {
		this.userToken = localStorage.getItem('validToken');

		if (this.userToken !== null) {
			var base64Url = this.userToken.split('.')[1];
			var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
			var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
				return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
			}).join(''));

			this.decodedToken = JSON.parse(jsonPayload);
			this.loggedUserId = parseInt(this.decodedToken.unique_name);
		}


		
 
	}

});