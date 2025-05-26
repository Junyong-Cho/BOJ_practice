import java.io.IOException;

public class BOJ_2505 {
	
	static int n, a[], lp, rp, i, j;
	static StringBuilder sb;

	public static void main(String catchsunpie[]) throws IOException{
		n = nex();
		a = new int[n+1];
		
		for(int i = 1; i <= n; i++)
			a[i] = nex();
		
		for(lp = 1; lp<n&&a[lp]==lp; lp++);
		if(lp==n) {
			System.out.println("1 1\n1 1");
			return;
		}
		sb = new StringBuilder();
		for(rp = n; a[rp]==rp; rp--);
		
		if(a[lp]==rp&&a[rp]==lp) {
			for(i = lp+1; i<rp&a[i-1]-1==a[i]; i++);
			if(i==rp) {
				sb.append(lp).append(" ").append(lp).append("\n");
				sb.append(lp).append(" ").append(rp);
			}
			else {
				for(j = rp-1; a[j+1]+1==a[j]; j--);
				sb.append(i).append(" ").append(j).append("\n");
				sb.append(lp).append(" ").append(rp);
			}
		}
		else if(a[lp]<a[rp]) {
			sb.append(lp).append(" ").append(a[lp]).append("\n");
			sb.append(a[rp]).append(" ").append(rp);
		}
		else if(a[lp]==rp) {
			if(a[rp-1]+1==a[rp]) {
				for(i = rp-1; a[i-1]+1==a[i]; i--);
				sb.append(i).append(" ").append(rp).append("\n");
				sb.append(lp).append(" ").append(rp);
			}
			else {
				sb.append(lp).append(" ").append(a[rp]).append("\n");
				sb.append(a[rp]).append(" ").append(rp);
			}
		}
		else if(a[rp]==lp) {
			if(a[lp]+1==a[lp+1]) {
				for(i = lp+1; a[i+1]==a[i]+1;i++);
				sb.append(lp).append(" ").append(i).append("\n");
				sb.append(lp).append(" ").append(rp);
			}
			else {
				sb.append(a[lp]).append(" ").append(rp).append("\n");
				sb.append(lp).append(" ").append(a[lp]);
			}
		}
		else if(a[lp]+1==a[lp+1]&&a[rp]-1==a[rp-1])	{
			if(a[lp+1]==rp) {
				sb.append(lp+1).append(" ").append(rp).append("\n");
				sb.append(lp).append(" ").append(rp-1);
			}
			else {
				sb.append(lp).append(" ").append(rp-1).append("\n");
				sb.append(lp+1).append(" ").append(rp);
			}
		}
		else if(a[lp]+1==a[lp+1]) {
			for(i = lp+1; a[i]!=lp; i++);
			sb.append(lp).append(" ").append(i).append("\n");
			sb.append(a[rp]).append(" ").append(rp);
		}
		else {
			for(i = lp+1; a[i]!=rp; i++);
			sb.append(i).append(" ").append(rp).append("\n");
			sb.append(lp).append(" ").append(a[lp]);
		}
		
		System.out.println(sb);
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
