
	public LayerMask RayAware;
	int reflected=0;
	void ReflectBullet()
	{
		if(reflected>2)return;

		Vector2 frompos = transform.position;
		Vector2 tovec = transform.TransformVector(1f,0,0);

		RaycastHit2D hit = Physics2D.Raycast(frompos, tovec, 1f, RayAware);

		if (hit.collider != null)
		{
			Vector2 calc=tovec;
			calc=Vector2.Reflect(calc.normalized,hit.normal);

			transform.rotation=Quaternion.Euler(0,0,getZdir(Vector3.zero,calc));
			reflected++;
		}
	}
	
	float getZdir(Vector2 me, Vector2 you)
	{	
		Vector2  calc=you-me;
		Vector2  nrm=new Vector2(1,0);

		float angles=Vector2.Angle(calc,nrm);

		Vector3 cross=Vector3.Cross(calc,nrm);
		if (cross.z>0)angles=360f-angles;

		return angles;
	}
