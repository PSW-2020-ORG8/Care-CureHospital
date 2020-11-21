function toLatinConvert(string) {
    var cyrillic = 'А_Б_В_Г_Д_Ђ_Е_Ё_Ж_З_И_Й_Ј_К_Л_Љ_М_Н_Њ_О_П_Р_С_Т_Ћ_У_Ф_Х_Ц_Ч_Џ_Ш_Щ_Ъ_Ы_Ь_Э_Ю_Я_а_б_в_г_д_ђ_е_ё_ж_з_и_й_ј_к_л_љ_м_н_њ_о_п_р_с_т_ћ_у_ф_х_ц_ч_џ_ш_щ_ъ_ы_ь_э_ю_я'.split('_')
    var latin = 'A_B_V_G_D_Đ_E_Ë_Ž_Z_I_J_J_K_L_Lj_M_N_Nj_O_P_R_S_T_Ć_U_F_H_C_Č_Dž_Š_Ŝ_ʺ_Y_ʹ_È_Û_Â_a_b_v_g_d_đ_e_ë_ž_z_i_j_j_k_l_lj_m_n_nj_o_p_r_s_t_ć_u_f_h_c_č_dž_š_ŝ_ʺ_y_ʹ_è_û_â'.split('_')

    return string.split('').map(function(char) {
      var index = cyrillic.indexOf(char)
      if (!~index)
        return char
      return latin[index]
    }).join('')
}


Vue.component("patientRegistration", {
	data: function () {
		return {
            showNotification : false,
            usernameInputField : '',
            errorForUsername : false,
            passwordInputField : '',
            confirmPasswordInputField : '',
            errorDifferentPassword : false,
            nameInputField : '',
            errorName : false,
            surnameInputField : '',
            errorSurname : false,
            jmbgInputField : '',
            errorJMBG : false,
            dateOfBirthDatePicker : '',
            state : {
                disabledDates: {
                    from: new Date(),
                }
            },

            contactNumberField : '',
            errorContactNumber : false,
            emailField : '',
            errorEmail : false,
            places : null,
		    city : '',
		    zipCode : '',
		    longitude : '',
		    latitude : '',
		    street : '',
		    number : '',
		    address: '',
            country : '',
            addressInput : '',
            errorAddress : false,
            imagesShow : [],
		    sendImages : [],
		    countImage : 0,
		    disable : false

		}
	},
	template: `
    <div>
    
    <div class="logo-and-name-patient-registration">
            <div class="logo-patient-registration ">        
                <img src="pictures/clinic.png"/>
            </div>
            <div class="web-name-patient-registration">
                <h3></h3>
            </div>  
        </div>

        <div class="main-patient-registration">     
            <ul class="menu-contents">
            <li><a href="#/">Utisci pacijenata</a></li>
            </ul>
        </div>

        <div class="dropdown">
            <button class="dropbtn">
                <img id="menuIcon" src="pictures/menuIcon.png" />
                <img id="userIcon" src="pictures/user.png" />
            </button>
        <div class="dropdown-content">
            <a>Registruj se</a>
            <a >Prijavi se</a>
        </div>
    </div>
	 
   
   <form id="form" action="" onsubmit="return false;"  method = "POST">
       <div class="confirm-cancel-field-patient-registration">
        <div class="confirm-cancel-field-patient-registration-title">
            <h1>Popunili ste potrebne podatke?</h1>
            <div class="add-btn-patient-registration">
                <button type="submit" v-on:click="registerPatient()">Registruj se</button>
            </div>
            <div class="cancle-btn-patient-registration">
                <button type="button" @click="previousButtonClicked()">Odustani</button>
            </div>
            <label v-if="showNotification" style="color:red; margin-left: 20%; font-size: 20px">Morate popuniti sve podatke!</label>
        </div>
    </div>
   
    <div class="fields-to-fill-patient-registration">

        <div class="wrapper-form-patient-registration">
            <div class="data-for-patient-registration">
                <div class="text-for-patient-registration">
                    <h1>Podaci za registraciju</h1>
                        <div class="scroll-in-patient-registration">
                            <label>Korisničko ime:</label>
                            <input v-model="usernameInputField" type="text" placeholder="Unesite korisničko ime..." pattern="[A-Za-z0-9ŠšĐđŽžČčĆć]*" title="Možete uneti slova i brojeve!">
                            <label v-if="errorForUsername" style="color:red; font-size: 16px">Možete uneti slova i brojeve!</label><br><br>
                        
                            <label>Lozinka:</label>
                            <input v-model="passwordInputField" type="password" placeholder="Unesite lozinku..."><br><br>

                            <label>Potvrda lozinke:</label>
                            <input v-model="confirmPasswordInputField" type="password" placeholder="Unesite ponovo lozinku...">
                            <label v-if="errorDifferentPassword" style="color:red; font-size: 16px">Lozinke se ne poklapaju!</label><br><br>

                            <label>Ime:</label>
                            <input v-model="nameInputField" type="text" placeholder="Unesite ime..." pattern="[A-ZŠĐŽČĆ][A-Za-zŠšĐđŽžČčĆć ]*" title="Prvo slovo mora biti veliko!">
                            <label v-if="errorName" style="color:red; font-size: 16px">Prvo slovo mora biti veliko!</label><br><br>

                            <label>Prezime:</label>
                            <input v-model="surnameInputField" type="text" placeholder="Unesite ime..." pattern="[A-ZŠĐŽČĆ][A-Za-zŠšĐđŽžČčĆć ]*" title="Prvo slovo mora biti veliko!">
                            <label v-if="errorSurname" style="color:red; font-size: 16px">Prvo slovo mora biti veliko!</label><br><br>

                            <label>JMBG:</label>
                            <input v-model="jmbgInputField" type="text" placeholder="Unesite ime..." pattern="[0-9]{13}" title="Možete uneti slova i brojeve!">
                            <label v-if="errorJMBG" style="color:red; font-size: 16px">JMBG se sastoji od 13 cifara!</label><br><br>

                            <label>Datum rođenja:</label><br/>
                            <vuejs-datepicker v-model="dateOfBirthDatePicker" type="date"  format="dd.MM.yyyy." :disabledDates="state.disabledDates" placeholder="Izaberite datum rođenja..." ></vuejs-datepicker><br>
                            
                            <label>Kontakt telefon:</label>
                            <input v-model="contactNumberField" type="text" placeholder="Unesite kontakt telefon..." pattern="[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*" title="Primer validnog kontakt telefona: +38166/123-123" >
                            <label v-if="errorContactNumber" style="color:red; font-size: 16px">Neispravan oblik kontakt telefona!</label><br><br>

                            <label>E-mail:</label>
                            <input v-model="emailField" type="text" placeholder="Unesite e-mail..." pattern="[\w-\.]+@([\w-]+\.)+[\w-]{2,4}" title="Primer za validan e-mail: pera.peric@gmail.com">
                            <label v-if="errorEmail" style="color:red; font-size: 16px">Neispravan oblik za e-mail!</label><br><br>

                            <label for="address">Adresa:</label><br><br>
                            <input id="address" v-model="addressInput" placeholder="Unesite adresu apartmana..." type="search" ><br><br>
                            
                            <input id="latitude" hidden>
                            <input id="longitude" hidden>
                            <input id="city" hidden>
                            <input id="zipCode" hidden>
                            <input id="country" hidden>
                            <input id="number" hidden>
                        
                            <br/><label>Profilna slika:</label><br/><br>
                            <input v-if="this.countImage <= 1" type="file"   @change="addImage" >
                            <input v-else type="file" disabled  @change="addImage" name="imagesForApartmentName"><br><br><br>
                        </div>

                </div>
            </div>
        </div>
    </div>
    </form>

	</div>
        
    `
    ,
	components : {
		vuejsDatepicker
    }
    ,
	methods: {
		registerPatient: function () {
            var empty = false;
            var differentPasswords = false
            var madeDateOfBirth = null;
            this.showNotification = false;
            this.errorForUsername = false;
            this.errorDifferentPassword = false;
            this.errorName = false;
            this.errorSurname = false;
            this.errorJMBG = false;
            this.errorContactNumber = false;
            this.errorEmail = false;
            this.errorAddress = false;

            if(this.usernameInputField.length === 0) {
				empty = true;
			} else {
				if(!this.usernameInputField.match(/^[A-Za-z0-9ŠšĐđŽžČčĆć]*$/)){
					this.errorForUsername = true;
					empty = true;
				}
            }
            
            if(this.passwordInputField.length === 0 || this.confirmPasswordInputField.length === 0) {
				empty = true;
			} else {
				if(this.passwordInputField !== this.confirmPasswordInputField){
                    this.errorDifferentPassword = true;
                    differentPasswords = true
				}
            }

            if(this.nameInputField.length === 0) {
				empty = true;
			} else {
				if(!this.nameInputField.match(/^[A-ZŠĐŽČĆ][A-Za-zŠšĐđŽžČčĆć ]*$/)){
					this.errorName = true;
					empty = true;
				}
            }

            if(this.surnameInputField.length === 0) {
				empty = true;
			} else {
				if(!this.surnameInputField.match(/^[A-ZŠĐŽČĆ][A-Za-zŠšĐđŽžČčĆć ]*$/)){
					this.errorSurname = true;
					empty = true;
				}
            }
            
            if(this.jmbgInputField.length === 0) {
				empty = true;
			} else {
				if(!this.jmbgInputField.match(/^[0-9]{13}$/)){
					this.errorJMBG = true;
					empty = true;
				}
            }
            
            if(this.dateOfBirthDatePicker === null || this.dateOfBirthDatePicker.length === 0) {
				empty = true;
			} else {
				let date = moment(this.dateOfBirthDatePicker).format("YYYY-MM-DD");
				madeDateOfBirth = new Date(date);	
            }
            
            if(this.contactNumberField.length === 0) {
				empty = true;
			} else {
				if(!this.contactNumberField.match(/^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$/)){
					this.errorContactNumber = true;
					empty = true;
				}
            }

            if(this.emailField.length === 0) {
				empty = true;
			} else {
				if(!this.emailField.match(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/)){
					this.errorEmail = true;
					empty = true;
				}
            }

            if(this.addressInput.length === 0 ){
				empty = true;			
			}else{
				this.address = toLatinConvert(document.querySelector('#address').value);
				this.longitude = toLatinConvert(document.querySelector('#longitude').value);
				this.latitude = toLatinConvert(document.querySelector('#latitude').value);
				this.city = toLatinConvert(document.querySelector('#city').value);
				this.zipCode = toLatinConvert(document.querySelector('#zipCode').value);
				this.country = toLatinConvert(document.querySelector('#country').value);
				//this.number = document.querySelector('#number').value;
				
				var streetAndNumber = this.addressInput.split(/(\d+)/);
				this.street = streetAndNumber[0].trim();
				this.number = streetAndNumber[1].trim();	
				
				if(this.country === "Serbia"){
					this.country = "Srbija";
				}
				
			}

			if (empty === false) {	
                if(!differentPasswords){
                    axios.post('/api/patientRegistration', {
                        username: this.usernameInputField,
                        password: this.passwordInputField,
                        name: this.nameInputField,
                        surname: this.surnameInputField,
                        jmbg: this.jmbgInputField,
                        dateOfBirth: madeDateOfBirth,
                        contactNumber: this.contactNumberField,
                        email: this.emailField,
                        address: {"street" : this.street, "houseNumber" : this.number, "city" : this.city, "postCode" : this.zipCode, "country" : this.country } 
                    })
                    .then(response => {
                        if(response.status === 200){
                            toast('Uspešno ste se registrovali, potvrdite Vaš identitet putem mejla')
                            this.usernameInputField = '';
                            this.passwordInputField = '';
                            this.confirmPasswordInputField = '';
                            this.nameInputField = '';
                            this.surnameInputField = '';
                            this.jmbgInputField = '';
                            this.dateOfBirthDatePicker = '';
                            this.contactNumberField = '';
                            this.emailField = '';
                            this.addressInput = '';
                            this.showNotification = false;
                            this.imagesShow = [],
                            this.sendImages = [],
                            this.countImage = 0
                        } else {
                            toast('Registracija nije uspešno izvršena!')
                        }
                        
                    });
                }		 	
			} else {
                this.showNotification = true; 
            }


        },
        previousButtonClicked : function(){	

            if(confirm('Da li ste sigurni da želite da odustanete od registracije?') === true){ 
                this.usernameInputField = '';
                this.passwordInputField = '';
                this.confirmPasswordInputField = '';
                this.nameInputField = '';
                this.surnameInputField = '';
                this.jmbgInputField = '';
                this.dateOfBirthDatePicker = '';
                this.contactNumberField = '';
                this.emailField = '';
                this.addressInput = ''; 
            }
        },
        
        addImage : function(e){

			const file = e.target.files[0];
			this.createBase64Image(file);
			this.countImage++;
			if(this.countImge === 1){
				this.disabled = true;
			}
			this.imagesShow.push(URL.createObjectURL(file));
		},
		
		createBase64Image : function(file){
			
			const reader = new FileReader();
			reader.onload = (e) => {
				let image = e.target.result;
				this.sendImages.push(image);				
				
			}		
			reader.readAsDataURL(file);
		}


	},
	mounted() {

        this.places = places({
			appId: 'plQ4P1ZY8JUZ',
			apiKey: 'bc14d56a6d158cbec4cdf98c18aced26',
			container: document.querySelector('#address'),
			templates: {
					value: function(suggestion){
						return suggestion.name;
				    }
			}
			}).configure({
					type: 'address'			
		});
		
		this.places.on('change', function getLocationData(e){		
			document.querySelector('#address').value = e.suggestion.value || '';
			document.querySelector('#city').value = e.suggestion.city || '';
			document.querySelector('#longitude').value = e.suggestion.latlng.lng || '';
			document.querySelector('#latitude').value = e.suggestion.latlng.lat || '';
			document.querySelector('#zipCode').value = e.suggestion.postcode || '';
			document.querySelector('#country').value = e.suggestion.country || '';
			//document.querySelector('#number').value = e.suggestion.number || '';
		});
	}

});