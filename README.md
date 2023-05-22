# PlayerApp
To insert the data to database using API
In Appsettings.Json need to change the sqlserver name Dbname and password to connect to local database
sampleInsert data https://localhost:44344/api/Player/AddPlayerdet?FullName=Kalees&Email=kaleesram&MobileNo=+971529094615&PlayerUserName=kaleeswaran&SocialCode=0897651d&Age=42&FbLink=https://fblnkkal&idprof=[{"idProofFrontSide":"Test.jpg","idProofFrontSide":"Test1.jpg"}]&signature=testdata&confrimlst=[{"i_am_not_Pregnant_or_Breast_feeder":"true","i_am_not_a_Diabetic_patient":"true","i_do_not_have_Psoriasis_or_any_chronic_skin_disease":"true","i_do_not_have_any_Blood_Disorders":"true","i_am_not_under_any_treatment_or_medications":"true"}]
For getting data:https://localhost:44344/api/Player/GetPlayerDet?id=1
I am using the EFcore
