Vue.component("eventSourcingStatistic", {
	data: function () {
		return {
			successfullyPercentage: 0,
			successfullyAvgTime: 0,
			unsuccessfullyAvgTime: 0,
			mostOftenQuitingStep: 0,
			dictAvgTimePerStep: [],
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
		<h3 style="color: #324960">Statistika praćenja događaja pri zakazivanju pregleda</h3>
		<table class="event-sourcing-statistic-table" style="margin-bottom:40px">
			<tr>
				<th style="min-width:430px;height:29px">Statistički parametar</th>
				<th style="min-width:90px;height:29px">Vrednost</th>			
			</tr>
			<tr>
				<td style="height:29px">Procenat uspešnog zakazivanja pregleda</td>
				<td style="height:29px">{{this.successfullyPercentage.toFixed(2) * 100}}%</td>
			</tr>
			<tr>
				<td style="height:29px">Procenat neuspešnog zakazivanja pregleda</td>
				<td style="height:29px">{{(1.0 - this.successfullyPercentage.toFixed(2)) * 100}}%</td>
			</tr>
			<tr>
				<td style="height:29px">Prosečno vreme uspešnog zakazivanja pregleda</td>
				<td style="height:29px">{{this.successfullyAvgTime.toFixed(2)}}s</td>
			</tr>
			<tr>
				<td style="height:29px">Prosečno vreme neuspešnog zakazivanja pregleda</td>
				<td style="height:29px">{{this.unsuccessfullyAvgTime.toFixed(2)}}s</td>
			</tr>
			<tr>
				<td style="height:29px">Korak na kom se najčešće odustaje</td>
				<td v-if="this.mostOftenQuitingStep === 1" style="height:29px">Izbor datuma</td>
				<td v-if="this.mostOftenQuitingStep === 2" style="height:29px">Izbor specijalizacije</td>
				<td v-if="this.mostOftenQuitingStep === 3" style="height:29px">Izbor doktora</td>
				<td v-if="this.mostOftenQuitingStep === 4" style="height:29px">Izbor termina</td>
			</tr>
			<tr>
				<td style="height:29px">Prosešno vreme provedeno na izboru datuma</td>
				<td style="height:29px">{{this.dictAvgTimePerStep[1].toFixed(2)}}s</td>
			</tr>
			<tr>
				<td style="height:29px">Prosešno vreme provedeno na izboru specijalizacije doktora</td>
				<td style="height:29px">{{this.dictAvgTimePerStep[2].toFixed(2)}}s</td>
			</tr>
			<tr>
				<td style="height:29px">Prosešno vreme provedeno na izboru doktora</td>
				<td style="height:29px">{{this.dictAvgTimePerStep[3].toFixed(2)}}s</td>
			</tr>
			<tr>
				<td style="height:29px">Prosešno vreme provedeno na izboru određenog termina</td>
				<td style="height:29px">{{this.dictAvgTimePerStep[4].toFixed(2)}}s</td>
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

		axios.get('gateway/appointment/getSuccessfulSchedulingPercentage', {
			headers: {
				'Authorization': 'Bearer ' + this.userToken
			}
		}).then(response => {
			this.successfullyPercentage = response.data;
			axios.get('gateway/appointment/getAverageSuccessfulSchedulingTime', {
				headers: {
					'Authorization': 'Bearer ' + this.userToken
				}
			}).then(response => {
				this.successfullyAvgTime = response.data;
				axios.get('gateway/appointment/getAverageUnsuccessfulSchedulingTime', {
					headers: {
						'Authorization': 'Bearer ' + this.userToken
					}
				}).then(response => {
					this.unsuccessfullyAvgTime = response.data;
					axios.get('gateway/appointment/getMostOftenQuitingStep', {
						headers: {
							'Authorization': 'Bearer ' + this.userToken
						}
					}).then(response => {
						this.mostOftenQuitingStep = response.data;
						axios.get('gateway/appointment/getAverageTimeSpentPerStep', {
							headers: {
								'Authorization': 'Bearer ' + this.userToken
							}
						}).then(response => {
							this.dictAvgTimePerStep = response.data;
						}).catch(error => {
							if (error.response.status === 401 || error.response.status === 403) {
								toast('Nemate pravo pristupa stranici!')
								this.$router.push({ name: 'userLogin' })
							}
						});
					}).catch(error => {
						if (error.response.status === 401 || error.response.status === 403) {
							toast('Nemate pravo pristupa stranici!')
							this.$router.push({ name: 'userLogin' })
						}
					});
				}).catch(error => {
					if (error.response.status === 401 || error.response.status === 403) {
						toast('Nemate pravo pristupa stranici!')
						this.$router.push({ name: 'userLogin' })
					}
				});
			}).catch(error => {
				if (error.response.status === 401 || error.response.status === 403) {
					toast('Nemate pravo pristupa stranici!')
					this.$router.push({ name: 'userLogin' })
				}
			});
		}).catch(error => {
			if (error.response.status === 401 || error.response.status === 403) {
				toast('Nemate pravo pristupa stranici!')
				this.$router.push({ name: 'userLogin' })
			}
		});
	}

});