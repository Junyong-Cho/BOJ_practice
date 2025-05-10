import java.io.IOException;

public class Main {
	
	static int n, m, ans;
	static boolean broken[] = new boolean[10];
	
	static public void main(String catchsunpie[]) throws IOException{
		n = nex();
		
		ans = abs(n-100);
		
		m = nex();
		
		while(m-->0)
			broken[nex()] = true;
		
		for(int i = 0; i < 10; i++) {
			if(broken[i]) continue;
			oper(i,1);
		}
		
		System.out.println(ans);
	}
	
	static void oper(int cur, int count) {
		int dif = abs(n-cur)+count;
		if(dif<ans) ans = dif;
		
		for(int i = 0; i < 10; i++) {
			if(broken[i]) continue;
			int ncur = (cur<<1) + (cur<<3) + i;
			int ndif = abs(n-ncur)+count+1;
			if(ndif<dif)
				oper(ncur,count+1);
		}
		
	}
	
	static int abs(int i) {
		return i<0?~i+1:i;
	}
	
	static int nex() throws IOException{
		int n,c;
		while((n = System.in.read())<=' ');
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return n;
	}

}
